using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.ViewComponents
{
    public class BasketBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
