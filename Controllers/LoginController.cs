using MyCollege.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCollege.Controllers
{
    [RoutePrefix("admin")]
    public class LoginController : Controller
    {
        // GET: Admin
        [Route("~/login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("~/login")]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                string returnUrl = string.Empty;
                if (user.UserName.Equals("admin") && user.Password.Equals("admin"))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("index", "Home");
                    else
                        return Redirect(returnUrl); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found, please enter correct details");
                    return View(user);
                }
            }
            else
                return View(user);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/home/index");
        }



    }
}