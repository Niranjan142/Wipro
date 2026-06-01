using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(
        string username,
        string password)
    {
        if(username == "admin"
            && password == "admin123")
        {
            HttpContext.Session.SetString(
                "User", username);

            HttpContext.Session.SetString(
                "Role", "Admin");

            return RedirectToAction(
                "Dashboard",
                "Transaction");
        }

        ViewBag.Message = "Invalid Login";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
