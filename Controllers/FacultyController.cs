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

        public ActionResult ManageNotification(string type)
        {
            List<NotificationMessage> items = null;
            string filepath = MyCollegeConstants.notificationJsonPath;
            if (!string.IsNullOrEmpty(type) && type.Equals(MyCollegeConstants.DownloadType))
                filepath = MyCollegeConstants.downloadsJsonPath;
            ViewBag.Message = "";
            ViewBag.NotificationType = type;
            using (StreamReader r = new StreamReader(Server.MapPath(filepath)))
            {
                string json = r.ReadToEnd();
                ViewBag.strJSON = json;
                items = JsonConvert.DeserializeObject<List<NotificationMessage>>(json);
            }
            return View(items);
        }

        [HttpPost]
        public ActionResult ManageNotification(string JSONString, string type)
        {
            List<NotificationMessage> items = null;
            string filepath = MyCollegeConstants.notificationJsonPath;
            if (type.Equals(MyCollegeConstants.DownloadType))
                filepath = MyCollegeConstants.downloadsJsonPath;
            string path = Server.MapPath(filepath);
            System.IO.File.WriteAllText(path, JSONString);
            ViewBag.Message = "Notifications changes Saved !";
            ViewBag.strJSON = JSONString;
            items = JsonConvert.DeserializeObject<List<NotificationMessage>>(JSONString);
            return View(items);
        }

        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase ImageData, string imageFileName, string type)
        {
            string filepath = MyCollegeConstants.facultyImgPath;
            if (type.Equals(MyCollegeConstants.DownloadType))
                filepath = MyCollegeConstants.downloadImgPath;
            else if (type.Equals(MyCollegeConstants.NotificationType))
                filepath = MyCollegeConstants.notificationImgPath;
            ImageData.SaveAs(Path.Combine(Server.MapPath(filepath), imageFileName));
            return View();
        }

    }
}