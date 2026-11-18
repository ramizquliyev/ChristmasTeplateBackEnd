using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
