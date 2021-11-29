using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {

        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment([FromForm] Comment p)
        {
            p.CommetDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
           
            cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
           var values= cm.GetList(id);
            return PartialView(values);
        }
    }
}
