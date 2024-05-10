using Microsoft.AspNetCore.Mvc;

namespace MeetingManagementSystem.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
