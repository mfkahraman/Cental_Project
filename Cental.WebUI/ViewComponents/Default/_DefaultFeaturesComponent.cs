using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFeaturesComponent(IFeatureService featureService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var features = featureService.TGetAll().Take(5).ToList();
            return View(features);
        }
    }
}
