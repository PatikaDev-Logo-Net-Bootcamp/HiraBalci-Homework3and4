using BackgroundQueue.API.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundQueue.API.Background
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IBackgroundQueue<Book> queue;//kitap işlemlerini buna göre yapacağım
        private readonly IServiceScopeFactory serviceFactory;// scopte olarak kullanmamı sağlayan interface
        private readonly ILogger<BackgroundWorker> logger;//loggerlama  için aldık.bunu kullanacağım için yazdım.

        public BackgroundWorker(IBackgroundQueue<Book> queue, IServiceScopeFactory serviceFactory, ILogger<BackgroundWorker> logger)
        {
            this.queue = queue;//bunlaro constructure ekledim bunlar oluşştu.
            this.serviceFactory = serviceFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("{Type} is now running in the background.", nameof(BackgroundWorker));//buraya log basalım
            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogCritical("The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.", nameof(BackgroundWorker));
            return base.StopAsync(cancellationToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken) //canceltoken iptal işlemini sağlıyor çok sık göreceğim bir yapı
        {
            while (!stoppingToken.IsCancellationRequested)//bu false olana kadar çalışmasını bekliyorum
            {
                try
                {
                    await Task.Delay(500, stoppingToken);//500 msnde bir beklesin
                    var book = queue.Dequeue();//önce br kuruğu boşaltsın
                    if (book == null) continue;//nullsa işeleme devam et.Döngün kırılmasın.

                    logger.LogInformation("Book Found! Starting to process");//işleme başla diye logladım.
                    using (var scope = serviceFactory.CreateScope())//bu scope arasında yazdığın scope yaptıktan sonra otomatikmen dispose işlemi yapar
                    {
                        var publisher = scope.ServiceProvider.GetRequiredService<IBookPublisher>();//işlemi publish edicem.
                        await publisher.Publish(book, stoppingToken);
                    }

                }
                catch (System.Exception ex)
                {
                    logger.LogError("An Error when publishing a book. Exception", ex);//eğer işlem de herhangi bir sıkıntı olursa burayı basacaktır.
                }
            }
        }
    }
}
