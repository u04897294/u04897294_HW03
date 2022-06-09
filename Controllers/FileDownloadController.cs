using u04897294_HW03.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u04897294_HW03.Controllers
{
    public class FileDownloadController : Controller
    {
        
        public ActionResult Index()
        {
            string[] strPath = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in strPath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            

            string path = Server.MapPath("~/Media/Documents/") + fileName;

           
            byte[] bytes = System.IO.File.ReadAllBytes(path);

           

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
           
            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}