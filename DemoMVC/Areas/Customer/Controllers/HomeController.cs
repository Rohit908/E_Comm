using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using DemoMVC.DataAccess.Data;

namespace DemoMVC.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly HtmlDbContext _html;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IConfiguration configuration, HtmlDbContext html)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _html = html;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category,CoverType");
            ViewBag.Menu = _html.Menus.ToList();
            return View(productList);
        }

        public IActionResult Details(int? id)
        {
            ShoppingCart cartObj = new ShoppingCart
            {
                Count = 1,
                Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id, includeProperties: "Category,CoverType")
            };
            
            return View(cartObj);
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

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }


    }
}