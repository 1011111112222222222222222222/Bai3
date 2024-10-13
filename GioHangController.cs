using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hoa.Models;
using Hoa.Helper;
using Microsoft.EntityFrameworkCore;
namespace Hoa.Controllers
{
	public class GioHangController : Controller
	{
		private readonly QlSpContext context;	
		public GioHangController(QlSpContext context)
		{
			this.context = context;
		}
		public List<CartItem>Get
		{
			get
			{
				var data=HttpContext.Session.Get<List<CartItem>>("GioHang");	
				if(data==null)
				{
					data=new List<CartItem>();
					
				}
				return data;
			}
		}
		public IActionResult AddToCart(int id, int SoLuong)
		{
			var myCart = Get;
			var item = myCart.SingleOrDefault(p => p.Mahh == id);
			if (item == null)//chưa có
			{
				var hangHoa = context.Products.SingleOrDefault(p => p.Masp == id);
				item = new CartItem
				{
					Mahh = id,
					Tenhh = hangHoa.Tensp,
					Dongia = (double)hangHoa.Gia.Value,
					SoLuong = SoLuong,
					Hinh = hangHoa.Hinh
				};
				myCart.Add(item);
			}
			else
			{
				item.SoLuong += SoLuong;
			}
			HttpContext.Session.Set("GioHang", myCart);

			return RedirectToAction("Index");
		}
		public IActionResult Index()
		{
			return View(Get);
		}
	}
}
