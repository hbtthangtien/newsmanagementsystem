using Microsoft.AspNetCore.Mvc;
using Persistences.Enum;
using UI.Filter;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    public class HomeController : Controller
    {
        [CustomAuthorize("staff")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
