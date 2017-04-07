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
            string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            //string constr = "Server=localhost;Port=5432;Database=cendris;User Id=postgres;Password=postgres;";

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO activiteit (activiteit,adres,plaats,oudere) VALUES (@activiteit, @adres, @locatie, 1)";
                        cmd.Parameters.Add(new NpgsqlParameter("@activiteit", Convert.ToString(Request["activiteit"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@adres", Convert.ToString(Request["adres"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@locatie", Convert.ToString(Request["locatie"])));
                        //cmd.Parameters.Add(new NpgsqlParameter("@datum", Convert.ToDateTime(Request["datum"])));
                        //cmd.Parameters.Add(new NpgsqlParameter("@uren", Convert.ToInt32(Request["uren"])));
                        //cmd.Parameters.Add(new NpgsqlParameter("@naam", Convert.ToString(Request["naam"])));

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
