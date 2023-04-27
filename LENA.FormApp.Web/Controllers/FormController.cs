using Microsoft.AspNetCore.Mvc;

namespace LENA.FormApp.Web.Controllers
{
    public class FormController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public IActionResult Forms(int id)
        {

            return View();
        }
    }
}
