// Controllers/HelloWorldController.cs
using Microsoft.AspNetCore.Mvc;

public class HelloWorldController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }

    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}
