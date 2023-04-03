using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisBookings.Areas.Admin.Models;

namespace TennisBookings.Areas.Admin;

[Area("Admin")]
[Route("Admin")]
[Authorize(Roles = "Admin")]
public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	[Route("Error")]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
