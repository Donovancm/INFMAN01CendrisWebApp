using InfomationManagementCendrisWebApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfomationManagementCendrisWebApp.Controllers
{
    public class ActiviteitenController : Controller
    {
        // GET: Activiteiten
        public ActionResult Index()
        {
            List<Activiteit> activiteitenLijst = new List<Activiteit>();
            string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {

                string query = "SELECT * FROM Activiteit";
                try
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                activiteitenLijst.Add(new Activiteit
                                {
                                    activity = Convert.ToString(dr["activiteit"]),
                                    address = Convert.ToString(dr["adres"]),
                                    location = Convert.ToString(dr["plaats"])
                                });
                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e); }
            }

            return View(activiteitenLijst);
        }
    }
}