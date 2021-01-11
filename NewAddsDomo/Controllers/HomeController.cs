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
    }
}