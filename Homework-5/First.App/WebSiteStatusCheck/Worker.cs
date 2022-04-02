using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebSiteStatusCheck
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;// loglama iþlemi yaptýðýmýz bir interface
        private HttpClient httpClient;//request atýcam webistesine ayakta mý diye.

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)//  bu executeAsync'i baþlatacaktýr.
        {
            httpClient = new HttpClient();//instanst almam lazým ki ben metotlarýmý kullanayým.
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)//iþlemi kapatýyor durdurludu diye log basabilirsin.
        {
            httpClient.Dispose();//durduðunda yaptýðým tüm iþlemleri ramden atsýn þiþme olmasýn.
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()//workerýmý silen methodum
        {
            base.Dispose();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) //buda uzun iþleri yapýcak.
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                // var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").Result.Content.ReadAsStringAsync();//http client tan get veya post yapabilirsin ben get yaptým.siteye istek attým.Bana bu api'daki result sonucunda dönen bilgileri string olarak oku.
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");//veri tabanýna git bu kaydý bas 
                
                if (request.IsSuccessStatusCode)//eðer 200 kodu gelirse
                {
                   _logger.LogInformation("Json Place Holder Data {0}", request.Content.ReadAsStringAsync().Result);//doðruysa log basalým.$ kullanmamýza gerek yok log methodundan ötürü.Sonuna awaitte yazabilirsin.
             
                }
                else
                {
                    _logger.LogError("Error Status Code",request.StatusCode);//yanlýþ olunca hata kodu dnecek1 dkda bir
                }
               
                await Task.Delay(60000, stoppingToken);//hangi aralýklarla çalýþacaðýný belirtebiliyorum  60 sn giriyorum.
            }
        }
    }
}
