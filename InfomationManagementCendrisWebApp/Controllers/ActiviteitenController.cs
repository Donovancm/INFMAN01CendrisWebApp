using InfomationManagementCendrisWebApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
                                    id = Convert.ToInt32(dr["activiteit_id"]),
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
        public ActionResult ActiviteitenInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Activiteit> activiteit = new List<Activiteit>();
            string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(constr))
            {

                string query = "SELECT * FROM Activiteit WHERE activiteit_id = "+id+";";
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
                                activiteit.Add(new Activiteit
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

            if (activiteit == null)
            {
                return HttpNotFound();
            }

            return View(activiteit);
        }
    }
}