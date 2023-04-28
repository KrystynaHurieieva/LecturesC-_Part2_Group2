using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View("Index");
		}
		public IActionResult View()
		{
			return View("View");
		}
		//[AcceptVerbs(System.Web.Mvc.HttpVerbs.Post.ToString() | System.Web.Mvc.HttpVerbs.Get.ToString())]
		public IActionResult PutIndex()
		{
			return View("Index");
		}

		public IActionResult Privacy()
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public System.Web.Mvc.JavaScriptResult WarningMessage()
		{
			return new System.Web.Mvc.JavaScriptResult() 
				{ Script = "alert('Are you want to Continue?')" };
		}
	}
}

// localhost:12435/api/myName/Ivan/id=1,lastname=test
// {Controller}/{action}/{id}