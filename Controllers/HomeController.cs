using MyCollege.Common;
using MyCollege.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MyCollege.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home";
            var files = Directory.EnumerateFiles(Server.MapPath(@"~/assets/img/slide"), "*.*", SearchOption.AllDirectories);


            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                    imageFiles.Add(Path.GetFileNameWithoutExtension(filename));
            }
            return View(imageFiles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Gallery";
            var files = Directory.EnumerateFiles(Server.MapPath(@"~/assets/img/portfolio"), "*.*", SearchOption.AllDirectories);
           

            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                    imageFiles.Add(Path.GetFileNameWithoutExtension(filename));
            }
            return View(imageFiles);
        }

        public ActionResult Faculty()
        {
            ViewBag.Message = "Faculties";

            List<Faculty> items = null;
            using (StreamReader r = new StreamReader(Server.MapPath(MyCollegeConstants.facultyJsonPath)))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Faculty>>(json);
            }
            return View(items);                       
        }
    }
}