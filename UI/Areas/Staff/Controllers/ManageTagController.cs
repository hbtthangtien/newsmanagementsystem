using Microsoft.AspNetCore.Mvc;
using UI.Filter;

namespace UI.Areas.Staff.Controllers
{
    [Area("staff")]
    [CustomAuthorize("staff")]
    public class ManageTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
