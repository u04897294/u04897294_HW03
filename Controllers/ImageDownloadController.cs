using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using u04897294_HW03.Models;
using System.Linq;
using System.Web;


namespace u04897294_HW03.Controllers
{
    public class ImageDownloadController : Controller
    {

        public ActionResult Index()
        {

            string[] strPath = Directory.GetFiles(Server.MapPath("/Media/Images"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in strPath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath)});

            }
            return View(files);
        }

        public FileResult DownloadImg(string fileName)
        {



            string path = Server.MapPath("~/Media/Images")  + "/" + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }


        public ActionResult DeleteImg(string fileName)
        {

            string path = Server.MapPath("~/Media/Images") +"/" + fileName;
            
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}