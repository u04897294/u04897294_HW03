using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u04897294_HW03.Controllers
{
    public class HomeController : Controller
    {
 

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string selected)
        {
           if (file != null && file.ContentLength > 0)
           {
               string filename = Path.GetFileName(file.FileName);
               string filepath = Path.Combine(Server.MapPath("/Media/" + selected), filename);
               file.SaveAs(filepath);
           }
            return RedirectToAction("Index");

        }



        public ActionResult About()
        {
                ViewBag.Message = "Your application description page.";

                return View();
        }
      

    }
}



       


