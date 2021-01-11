using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewAddsDemo.Controllers;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using NewAddsDomo.Models;
using System.Web.Security;
using Facebook;

namespace NewAddsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NewAddsModel na,HttpPostedFileBase file)
        {

            String mainconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);

            String sqlq = "insert into RegUser(FirstName,LastName,Email,Pwd,Gender,Location,Phonenumber,Rimg) values(@FirstName,@LastName,@Email,@Pwd,@Gender,@Location,@Phonenumber,@Rimg)";
            SqlCommand sqlcom = new SqlCommand(sqlq, sqlcon);
            sqlcon.Open();
            sqlcom.Parameters.AddWithValue("@FirstName", na.FirstName);
            sqlcom.Parameters.AddWithValue("@LastName", na.FirstName);
            sqlcom.Parameters.AddWithValue("@Email", na.FirstName);
            sqlcom.Parameters.AddWithValue("@Pwd", na.FirstName);
            sqlcom.Parameters.AddWithValue("@Gender", na.FirstName);
            sqlcom.Parameters.AddWithValue("@Location", na.FirstName);
            sqlcom.Parameters.AddWithValue("@Phonenumber", na.FirstName);

            if(file!=null &&file.ContentLength>0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/RegImg/"), filename);
                file.SaveAs(imgpath);
            }
            sqlcom.Parameters.AddWithValue("@Phonenumber", "~/RegImg/" + file.FileName);
            sqlcom.ExecuteNonQuery();
            ViewData["Message"] = "User Is Registerd "+na.FirstName+ " Successfully ";
          
            sqlcon.Close();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private Uri RediredtUri
        {

            get
            {

                var uriBuilder = new UriBuilder(Request.Url);

                uriBuilder.Query = null;

                uriBuilder.Fragment = null;

                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;

            }

        }

        [AllowAnonymous]

        public ActionResult Facebook()

        {

            var fb = new FacebookClient();

            var loginUrl = fb.GetLoginUrl(new

            {




                client_id = "Your App ID",

                client_secret = "Your App Secret key",

                redirect_uri = RediredtUri.AbsoluteUri,

                response_type = "code",

                scope = "email"



            });

            return Redirect(loginUrl.AbsoluteUri);

        }




        public ActionResult FacebookCallback(string code)
        {

            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = "Your App ID",

                client_secret = "Your App Secret key",

                redirect_uri = RediredtUri.AbsoluteUri,

                code = code

            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,age_range");

            string email = me.email;

            TempData["email"] = me.email;

            TempData["first_name"] = me.first_name;

            TempData["lastname"] = me.last_name;


            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("Index", "Home");

        }


    }
}