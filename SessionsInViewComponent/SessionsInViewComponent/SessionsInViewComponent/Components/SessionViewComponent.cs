using Microsoft.AspNetCore.Mvc;

namespace SessionsInViewComponent.Components
{
    public class SessionViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessionViewComponent(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public IViewComponentResult Invoke()
        {
            object cartItems = _httpContext.HttpContext.Session.GetString("cartItems");
            if (cartItems == null)
            {
                _httpContext.HttpContext.Session.SetString("cartItems", "1");
                cartItems = "1";
            }
            else
            {
                var items = int.Parse(cartItems.ToString());
                items++;
                _httpContext.HttpContext.Session.SetString("cartItems", items.ToString());
            }
            return View(cartItems);
        }
    }
}