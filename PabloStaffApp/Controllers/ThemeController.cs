using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index( string returnUrl = null)
        {
            // Default Layout 
            string layout = "_Layout";

            // Customize Layouts
            string selectedLayout = Request.Query["theme"];

            string sessionValue = HttpContext.Session.GetString("Layout");
            if (!string.IsNullOrEmpty(sessionValue))
            {
                layout = sessionValue;
            }

            if (selectedLayout == "Theme1")
            {
                layout = "_Layout";
                HttpContext.Session.SetString("Layout", $"~/Views/Shared/{layout}.cshtml");
            }
            if (selectedLayout == "Theme2")
            {
                layout = "_LayoutTheme2";
                HttpContext.Session.SetString("Layout", $"~/Views/Shared/{layout}.cshtml");
            }
            if (selectedLayout == "Theme3")
            {
                layout = "_LayoutTheme3";
                HttpContext.Session.SetString("Layout", $"~/Views/Shared/{layout}.cshtml");
            }

            if (string.IsNullOrEmpty(sessionValue))
            {
                HttpContext.Session.SetString("Layout", $"~/Views/Shared/{layout}.cshtml");
            }

            string backUrl = Request.Query["backUrl"];
            if (backUrl == "Home")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Emp");
            }
        }
    }
}
