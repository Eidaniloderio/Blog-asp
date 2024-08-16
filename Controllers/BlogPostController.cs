using Blog_asp.Data;
using Blog_asp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

namespace Blog_asp.Controllers
{
    public class BlogPostController : Controller
    {
        readonly private ApplicationDbContext _db;
        public BlogPostController(ApplicationDbContext db) 
        {
            _db = db;

        }

        public IActionResult CriarPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarPost(BlogPostModel Post)
        {
            if (ModelState.IsValid)
            {
                _db.BlogPosts.Add(Post);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            } 
            return View();
        }

        [HttpPost]

        public IActionResult EditarPost(BlogPostModel Post)
        {
            if (ModelState.IsValid)
            {
                _db.BlogPosts.Update(Post);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(Post);
        }


        [HttpGet]
        public IActionResult ExibirPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            BlogPostModel post = _db.BlogPosts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpGet]
        public IActionResult EditarPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            BlogPostModel post = _db.BlogPosts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult DeletarPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            BlogPostModel post = _db.BlogPosts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            _db.BlogPosts.Remove(post);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");


        }
    }
}
    