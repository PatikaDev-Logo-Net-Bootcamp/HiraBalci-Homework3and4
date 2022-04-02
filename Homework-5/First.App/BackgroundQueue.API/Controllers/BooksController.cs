using BackgroundQueue.API.Background;
using BackgroundQueue.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController : ControllerBase
    {
        private readonly IBackgroundQueue<Book> queue;// queue alıcakssam ibackground interface 'i yardımımıza koşuyor.Generic interface book diyoruz.

        public BooksController(IBackgroundQueue<Book> queue)
        {
            this.queue = queue;
        }

        [HttpPost]//post eden metot yazacağız
        //artık kitap yayınlandı diye butona basacktır.beklemeden worker kuyruğa alıcak kullanıcı beklemeyecek
        public IActionResult Publish([FromBody] Book book)
        {
            queue.Enqueue(book);//kitabın bilgilerini kuyruğa alıyor.
            return Accepted();//202 yi dönebiliyorsunuz işleminiz sıraya alındı şeklinde dönüyor.
        }
    }
}
