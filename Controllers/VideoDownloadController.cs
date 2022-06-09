using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u04897294_HW03.Models;

namespace u04897294_HW03.Controllers
{
    public class VideoDownloadController : Controller
    {
       
        public ActionResult Index()
        {
            string[] strPath = Directory.GetFiles(Server.MapPath("/Media/Videos"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in strPath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
            
        }

        public FileResult DownloadVid(string fileName)
        {



            string path = Server.MapPath("~/Media/Videos") + "/" + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }


        public ActionResult DeleteVid(string fileName, string filePath2)
        {

            string path = Server.MapPath("~/Media/Videos")  + "/" + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}