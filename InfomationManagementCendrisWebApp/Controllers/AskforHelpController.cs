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

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO activiteit (activiteit,naam_oudere,verzorgingstehuis,adres,locatie,datumtijd,tijdsduur) VALUES (@activiteit, @naam, @tehuis, @adres, @locatie, @datum, @uren)";
                        cmd.Parameters.Add(new NpgsqlParameter("@activiteit", Convert.ToString(Request["activiteit"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@naam", Convert.ToString(Request["naam"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@tehuis", Convert.ToString(Request["tehuis"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@adres", Convert.ToString(Request["adres"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@locatie", Convert.ToString(Request["locatie"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@datum", Convert.ToDateTime(Request["datum"])));
                        cmd.Parameters.Add(new NpgsqlParameter("@uren", Convert.ToInt32(Request["uren"])));

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
