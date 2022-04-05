using First.App.Business.Abstract;
using First.App.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PostWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;// loglama iþlemi yaptýðýmýz bir interface
        private HttpClient httpClient;//request atýcam webistesine ayakta mý diye.

        private readonly IServiceScopeFactory _service;
        public Worker(ILogger<Worker> logger, IServiceScopeFactory service)
        {
            _logger = logger;
            _service = service;

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
                    //_logger.LogInformation("Json Place Holder Data {0}", request.Content.ReadAsStringAsync().Result);//doðruysa log basalým.$ kullanmamýza gerek yok log methodundan ötürü.Sonuna awaitte yazabilirsin.
                    var response = await request.Content.ReadAsStringAsync();

                    var posts = JsonConvert.DeserializeObject<List<Post>>(response);
                    try
                    {
                        using (var scope = _service.CreateScope())
                        {
                            var myScopedService = scope.ServiceProvider.GetRequiredService<IPostService>();
                            myScopedService.AddPosts(posts);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }


                    // _postservice.AddPosts(posts);
                }
                else
                {
                    _logger.LogError("Error Status Code", request.StatusCode);//yanlýþ olunca hata kodu dnecek1 dkda bir
                }

                await Task.Delay(60000, stoppingToken);//hangi aralýklarla çalýþacaðýný belirtebiliyorum  60 sn giriyorum.
            }
        }
    }
}
