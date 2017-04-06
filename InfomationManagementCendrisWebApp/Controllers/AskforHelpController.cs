using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfomationManagementCendrisWebApp.Controllers
{
    public class AskForHelpController : Controller
    {
        // GET: AskforHelp
        public ActionResult Index()
        {
            ViewBag.Message = "Opzetten van een activiteit";
            
            return View();
        }
        // GET: /AskforHelp/Dashboard
        public ActionResult Dashboard()
        {
            string constr = ConfigurationManager.ConnectionStrings["cendris"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO activiteit (name,activiteit) VALUES (@naam, @activiteit)";
                        cmd.Parameters.Add(new NpgsqlParameter("@naam", Convert.ToString(Request["naam"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@activiteit", Convert.ToString(Request["activiteit"])));

                        // Insert some data
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e); }
            }

            return View();
        }
    }
}
