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
        private readonly ILogger<Worker> _logger;// loglama i�lemi yapt���m�z bir interface
        private HttpClient httpClient;//request at�cam webistesine ayakta m� diye.

        private readonly IServiceScopeFactory _service;
        public Worker(ILogger<Worker> logger, IServiceScopeFactory service)
        {
            _logger = logger;
            _service = service;

        }


        public override Task StartAsync(CancellationToken cancellationToken)//  bu executeAsync'i ba�latacakt�r.
        {
            httpClient = new HttpClient();//instanst almam laz�m ki ben metotlar�m� kullanay�m.
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)//i�lemi kapat�yor durdurludu diye log basabilirsin.
        {
            httpClient.Dispose();//durdu�unda yapt���m t�m i�lemleri ramden ats�n �i�me olmas�n.
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()//worker�m� silen methodum
        {
            base.Dispose();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) //buda uzun i�leri yap�cak.
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                // var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").Result.Content.ReadAsStringAsync();//http client tan get veya post yapabilirsin ben get yapt�m.siteye istek att�m.Bana bu api'daki result sonucunda d�nen bilgileri string olarak oku.
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");//veri taban�na git bu kayd� bas 

                if (request.IsSuccessStatusCode)//e�er 200 kodu gelirse
                {
                    //_logger.LogInformation("Json Place Holder Data {0}", request.Content.ReadAsStringAsync().Result);//do�ruysa log basal�m.$ kullanmam�za gerek yok log methodundan �t�r�.Sonuna awaitte yazabilirsin.
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
                    _logger.LogError("Error Status Code", request.StatusCode);//yanl�� olunca hata kodu dnecek1 dkda bir
                }

                await Task.Delay(1000, stoppingToken);//hangi aral�klarla �al��aca��n� belirtebiliyorum  60 sn giriyorum.
            }
        }
    }
}
