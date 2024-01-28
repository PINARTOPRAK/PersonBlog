using Microsoft.AspNetCore.Mvc;
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
            BlogModel blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            List<CommentModel> comments = _context.Comments.Where(c => c.BlogId == id).ToList();
            blog.Comments = comments;
            return View(blog);
            //BlogModel blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();  //burada id kolonundan blogu veritabanında bulup getirdik.
            //return View(blog);// Burda bir tane blog getirmiş olduk
        }
        public IActionResult AddComment(int blogId, string content)
        {
            // Eğer kullanıcı giriş yapmışsa devam et
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcının adını al
                string userName = User.Identity.Name;

                // CommentModel'in BlogId alanını kullanarak bir örnek oluşturun
                CommentModel comment = new CommentModel
                {
                    BlogId = blogId,
                    UserName = userName,
                    Content = content
                };

                // CommentModel'i veritabanına ekleyin
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }

            // Blog detay sayfasına yönlendir
            return RedirectToAction("Detay", new { id = blogId });
        }


    }
}