using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
