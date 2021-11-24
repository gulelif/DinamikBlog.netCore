
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetList();
            return View(values);
        }
    }
}
