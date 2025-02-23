using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    public class ManageNewsArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
