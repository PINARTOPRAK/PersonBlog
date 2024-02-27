using FFImageLoading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonBlog.Data;
using PersonBlog.Models;

namespace PersonBlog.Controllers
{
	[Authorize]
    public class AdminController : Controller
	{
		private readonly ApplicationDbContext _context;
        
        public AdminController(ApplicationDbContext context)
		{
			_context = context;
           
        }
		public IActionResult Blogs() //buradan başlatman gerek
        {
			List<BlogModel> blogs = _context.Blogs.ToList();  //blogları veritabanından getiriyor
			return View(blogs);
        }
		public IActionResult AddBlog() //blog eklemeye tıkladığında buraya yönlenecek
		{
			return View();
		}



		[HttpPost]
		public IActionResult AddBlog(BlogModel blog) 
		{
			_context.Blogs.Add(blog); //veritabanına kaydı ekliyor
			_context.SaveChanges(); //burada veritabanını kaydediyor.
            return RedirectToAction("Blogs");  //sayfayı yönlendiriyoruz
        }
		public IActionResult RemoveBlog(int id)
		{
			BlogModel blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault(); //id ile blogu veritabanından getiriyor
			_context.Blogs.Remove(blog); //burada siliyor
			_context.SaveChanges(); //burada veritabanını kaydediyor.
			return RedirectToAction("Blogs");  //sayfayı yönlendiriyoruz
		}
		public IActionResult UpdateBlog(int id) //düzenleye bastığımızda ilk buraya geliyor
		{
			BlogModel blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();  //id ile blogu veritabanından getiriyor
            return View(blog); //blogu gönderiyoruz.
		}
		[HttpPost]
		public IActionResult UpdateBlog(BlogModel blog)
		{
			BlogModel selectedBlog = _context.Blogs.Where(x => x.Id == blog.Id).FirstOrDefault(); //id ile blogu veritabanından getiriyor
            selectedBlog.Title = blog.Title; //veritabanındaki kayıt ile ön tarafataki kayıtları güncelliyoruz.
			selectedBlog.Summary = blog.Summary;
			selectedBlog.Content = blog.Content;
			selectedBlog.Update_Date = DateTime.Now;
			_context.SaveChanges();
			return RedirectToAction("Blogs"); //sayfayı yönlendiriyoruz
        }

		
	}
}
