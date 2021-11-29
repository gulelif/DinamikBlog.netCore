using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var cities = new List<CityModel>() {
            new CityModel(){CityId=1,CityName="İstanbul" },
            new CityModel(){CityId=2,CityName="Bolu" },
            new CityModel(){CityId=3,CityName="Adana" },
            new CityModel(){CityId=4,CityName="Konya" },
            new CityModel(){CityId=5,CityName="Ankara" }
            };
            ViewBag.cities = new SelectList(cities, "CityId", "CityName");
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
