using Npgsql;
using System;
using System.Collections.Generic;
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
            using (NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=tryINFMAN;"))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO activiteit (name,activiteit) VALUES (@name, @activity)";
                        cmd.Parameters.Add(new NpgsqlParameter("@name", Convert.ToString(Request["name"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@activity", Convert.ToString(Request["activity"])));

                        // Insert some data
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e);}
            }

            return View();
        }
    }
}
