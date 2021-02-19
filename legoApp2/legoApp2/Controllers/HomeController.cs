using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using legoApp2.Models;

namespace legoApp2.Controllers
{
    public class HomeController : Controller
    {
        /*
        Public string index()
        {
            Return "<h1>Hei fra controller</h1> "();
        }
        */

public ActionResult index()
        {
            return View();
        }


        public ActionResult about()
        {
            return View();
        }

        public string WhatIWrote(String id)
        {
            return "Du tastet inn: " + id;
        }

        public ActionResult buy()
        {
            return View();
        }
        public ActionResult VisAlleLegosett()
        {
            List<Legosett> LegosettList = new List<Legosett>
                {
                new Legosett { Navn = "harry Potter lekestue", AntallDeler = 130, Pris = 344, Bilde = "hp.jpg"
                 },
                 new Legosett
                 {
                Navn = "harry Potter lekestue1",
                AntallDeler = 130,
                Pris = 344,
                Bilde = "hp1.jpg"
                },

                  new Legosett
                 {
                Navn = "harry Potter lekestue2",
                AntallDeler = 130,
                Pris = 344,
                Bilde = "hp2.jpg"
                },

                   new Legosett
                 {
                Navn = "harry Potter lekestue3",
                AntallDeler = 130,
                Pris = 344,
                Bilde = "hp3.jpg"
                }

                };

            return View(LegosettList);
        }

    }
}