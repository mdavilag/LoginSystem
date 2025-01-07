using Microsoft.AspNetCore.Mvc;

namespace LoginSystemApi.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
