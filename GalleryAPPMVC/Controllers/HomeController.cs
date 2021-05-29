using GalleryAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleryAPPMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentView(Person person)
        {

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection connect = new SqlConnection(strcon);
            connect.Open();
            SqlCommand cmd = new SqlCommand("GalleryLogin", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@UserName", person.UserName);
            cmd.Parameters.AddWithValue("@Password", person.Password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            String dataSetUserName;
            String dataSetPassword;

            if (ds.Tables[0].Rows.Count > 0)
            {

                dataSetUserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                dataSetPassword = ds.Tables[0].Rows[0]["Password"].ToString();

                if (dataSetUserName == person.UserName && dataSetPassword == person.Password)
                {

                    return View("Gallery");
                }
                else
                {
                    person.Message = "Invalid Login";
                }
            }
            else
            {
                person.Message = "Invalid UserName and Password";
            }

            return View("Gallery");
        }
    
        
       
        
    }
}