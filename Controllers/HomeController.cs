using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kartkowkaMVC.Models;

namespace kartkowkaMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Create()
    {
        Random rnd = new Random();
        for(int i = 0; i < 5; i++)
        {
            Number.list.Add(new Number(rnd.Next(1, 9)));
        }

        return View();
    }

    public IActionResult Read()
    {
        ViewBag.numberList = Number.list.OrderByDescending(x=>x.Value).Where(x=>x.Value > 4).ToList();
        return View();
    }
    
    public IActionResult Update(int id)
    {
        Random rnd = new Random();
        Number.list.Where(x=>x.Id == id).FirstOrDefault().Value = rnd.Next(10, 19);
        return RedirectToAction("Read", "Home");
    }
    
    public IActionResult Delete(int id)
    {
        Number.list.RemoveAll(x=>x.Value > 9);
        return RedirectToAction("Read", "Home");
    }
}