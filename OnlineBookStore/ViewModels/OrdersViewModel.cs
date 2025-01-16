using Microsoft.AspNetCore.Mvc;

namespace OnlineBookStore.ViewModels
{
    public class OrdersViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
