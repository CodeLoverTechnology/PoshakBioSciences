using PoshakBioSciences.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoshakBioSciences.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!CommonFunction.CheckUserAuthentication())
            {
                return RedirectToAction("D2cLogin", "D2cHome");
            }
            if (!CommonFunction.CheckUserAccessAuthorization("View", Convert.ToInt32(Session["RoleID"].ToString()), "D2cHome"))
            {
                return RedirectToAction("UnAuthorised", "D2cHome");
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return View();
        }

        public ActionResult LoginAdmin()
        {
            ViewBag.LoginStatus = null;
            return View();
        }

        public ActionResult LogoutAdmin()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session["PrCode"] = null;
            Session["PrName"] = null;
            Session.RemoveAll();
            return RedirectToAction("LoginAdmin");
        }

        [HttpPost]
        [ActionName("LoginAdmin")]
        public ActionResult LoginAdmin(FormCollection collection)
        {
            try
            {
                var UserID = collection["loginname"].ToString();
                var PWD = collection["password"].ToString();
                ViewBag.LoginStatus = null;

                if (UserID == Resources.PoshakBioSciencesWebResources.Admin_User && PWD == Resources.PoshakBioSciencesWebResources.PBSAdmin_Pwd)
                {
                    Session["PrCode"] = Resources.PoshakBioSciencesWebResources.Admin_User;
                    Session["PrName"] = "Poshak Bio Science Admin";
                    Session["BranchID"] = "1";
                    Session["RoleID"] = Resources.PoshakBioSciencesWebResources.RoleAdmin;
                    return View("Index");
                }
                else
                {
                    ViewBag.LoginStatus = "Login ID and Password are not matched. Try again ...";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}