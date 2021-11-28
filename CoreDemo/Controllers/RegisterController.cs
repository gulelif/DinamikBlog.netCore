using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        
        [HttpGet] //sayfa yüklenice çalışır

        public IActionResult Index()
        {
          
            return View();
        }
        [HttpPost] //button tıklanınca çalışır
        public IActionResult Index(Writer w)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(w);
            if(result.IsValid)
            { 
            w.WriterStatus = true;
            w.WriterAbout = "Deneme Test";
            wm.WriterAdd(w);
                return RedirectToAction("Index","Blog");
                }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);

                }
            }


            return View();
        }
    }
}
