using Microsoft.AspNetCore.Mvc;
using Hoa.Models;
using Hoa.Helper;
namespace Hoa.Controllers
{
	public class NguoiDungController : Controller
	{
		QlSpContext data=new QlSpContext();
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult LoGin()
		{
			
			if (HttpContext.Session.GetString("Username") == null)
			{
				return View();
			}
			else
			{

				return RedirectToAction("ConnectSQL", "Index");
			}
		}
		[HttpPost]
		public IActionResult LoGin(Acount ac)
		{
			if (HttpContext.Session.GetString("Username") == null)
			{
				var us = data.Acounts.Where(t => t.Username.Equals(ac.Username) &&
				t.Pasword.Equals(ac.Pasword)).FirstOrDefault();
				if (us != null)
				{
					HttpContext.Session.SetString("Username", us.Username.ToString());
					return RedirectToAction("Product", "Index");
				}
			}
			else
			{

				return RedirectToAction("Product", "Index");
			}
			return View();
		}
	}
}
