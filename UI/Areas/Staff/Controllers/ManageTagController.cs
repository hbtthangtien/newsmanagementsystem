using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    public class ManageTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
