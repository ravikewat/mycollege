using MyCollege.Common;
using MyCollege.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyCollege.Controllers
{
    [Authorize]
    public class FacultyController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            List<Faculty> items = null;
            ViewBag.Message = "";
            using (StreamReader r = new StreamReader(Server.MapPath(MyCollegeConstants.facultyJsonPath)))
            {
                string json = r.ReadToEnd();
                ViewBag.strJSON = json;
                items = JsonConvert.DeserializeObject<List<Faculty>>(json);
            }
            return View(items);
        }

        [HttpPost]
        public ActionResult Index(string JSONString)
        {
            List<Faculty> items = null;
            string path = Server.MapPath(MyCollegeConstants.facultyJsonPath);
            System.IO.File.WriteAllText(path, JSONString);
            ViewBag.Message = "Faculties changes Saved !";
            ViewBag.strJSON = JSONString;
            items = JsonConvert.DeserializeObject<List<Faculty>>(JSONString);
            return View(items);
        }

        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase ImageData, string imageFileName)
        {
            ImageData.SaveAs(Path.Combine(Server.MapPath(MyCollegeConstants.facultyImgPath), imageFileName));
            return RedirectToAction("index", "faculty", null);
        }

    }
}