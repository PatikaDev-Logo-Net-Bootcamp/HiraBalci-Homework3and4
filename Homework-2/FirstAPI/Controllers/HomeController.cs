using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return Ok("success");
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Test([FromBody] TesterModel model)
        {
            var tester = new TesterModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                birthDay = model.birthDay,
            };
            return Ok(tester);//json dönüyor
        }

        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        //Swaggerda istediğim gibi 4 tane endpoint oluşturdum.Yukarıdaki kod ile delete attribute'unu ignore edebilirsin
        public IActionResult Delete()
        {
            return Json(new {success=true ,data="Hello world" });
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("success");
        }
    }
}
