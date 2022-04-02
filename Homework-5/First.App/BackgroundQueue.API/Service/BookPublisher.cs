using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundQueue.API.Service
{
    public interface IBookPublisher //interface oluşturdum
    {
        Task Publish(Book book, CancellationToken cancellationToken = default);//publish adında metot oluşturduk.cancel tokenda başlama ve durdurma işlemleri için alıyorum.
    }
    public class BookPublisher : IBookPublisher
    {
        private readonly ILogger<BookPublisher> _logger;//oluşturduğum sınıfı log luyorum

        public BookPublisher(ILogger<BookPublisher> logger)
        {
            _logger = logger;//publish işleminde veri tabanı okuma işlemi yapabilirim
        }

        public async Task Publish(Book book, CancellationToken cancellationToken = default) //yukarıda yazdığımla implement ediyorum
        {
            _logger.LogInformation("Doing heavy publishing logic");//asıl yapacağım işi buraya yazdım.
            await Task.Delay(3000, cancellationToken);//task delay ile beraber gecikme süreini yazıyorum.3 sn bekliyorum.
            _logger.LogInformation("{Name} by {Author} has been published!", book.Name, book.Author);//log ile bastırıyorum.interface classı yazdım startup ta configure servise enject etmemiz lazım
        }
    }
}
