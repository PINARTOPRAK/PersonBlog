using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonBlog.Data;
using PersonBlog.Models;
using System.Diagnostics;

namespace PersonBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context; //veritabanı bağlantı noktası
        public HomeController(ApplicationDbContext context)
        {
            _context = context; //veritabanının örneğini alıyoruz.
        }

        public IActionResult Index() //anasayfamız burada ilk açılış ekranı karşılıyor
        {
            List<BlogModel> blogs = _context.Blogs.ToList();  //veritabanından blogları çekiyoruz ve ekrana gönderiyoruz
            return View(blogs); // Bu bi liste blogları alıp gönderdiğimiz 
        }

        [Route("/detay/{id}")]  //blogların detayını yönlenmesi için ıd kolonunu kullandık
        public IActionResult Detay(int id)
        {
            //BlogModel blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();  //burada id kolonundan blogu veritabanında bulup getirdik.
            //Review rev = _context.Reviews.Where(x => x.Id == id).FirstOrDefault();

            var blog = _context.Blogs.Include(x => x.Reviews).Where(x => x.Id == id).Select(x => new
            {
                Title= x.Title,
                Content = x.Content,

                Name = x.Reviews.FirstOrDefault().Name,
                text = x.Reviews.FirstOrDefault().Text
            }).ToList();
            return View(blog);
        }

        [HttpPost]
        public IActionResult AddReview(string name, string Text)
        {
            var review = new Review
            {
                Text = Text,
                Name = name,

            };
            _context.Reviews.Add(review);
            _context.SaveChanges();

            return RedirectToAction("Detay.cshtml");
        }


    }
}