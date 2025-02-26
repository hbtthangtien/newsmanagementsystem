using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ManageDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
