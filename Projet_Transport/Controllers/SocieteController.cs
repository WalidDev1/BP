using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iText.StyledXmlParser.Jsoup.Nodes;
using Org.BouncyCastle.Asn1.X509;
using Projet_Transport.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class SocieteController : Controller
    {
        TransportEntitieslast db = new TransportEntitieslast();

        [Route("searsh")]
        public ActionResult searsh()
        {
            return View();
        }

        [Route("AddTrajet")]
        public ActionResult AddTrajet(int j = 0)
        {

            if (Session["Societe"] != null)
            {
                ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");
                ViewBag.id_Nbr_place = new SelectList(db.villes.ToList(), "id", "nom");
                ViewBag.id_type = new SelectList(db.villes.ToList(), "id", "nom");
                ViewBag.id_description = new SelectList(db.reservations.ToList(), "id");
                ViewBag.listeville = db.villes.ToList();
                societe so = (societe)Session["Societe"];
                if (db.cars.Where(c => c.id_societe == so.id).FirstOrDefault() != null)
                {
                    Session["haveCar"] = true;
                }
            }
            return View();
        }








        [HttpPost]
        [Route("AddTrajet")]
        public ActionResult AddTrajet()
        {
            ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");
            ViewBag.id_ville_depart = new SelectList(db.villes.ToList(), "id", "nomVille");
            ViewBag.id_ville_arrive = new SelectList(db.villes.ToList(), "id", "nomVille");
            ViewBag.listeville = db.villes.ToList();
            trajet trajet1 = new trajet();

            if (Session["Societe"] != null)
            {
                societe so = (societe)Session["Societe"];
              trajet1.idCar = so.id;
                try
                {

                    UpdateModel(trajet1);

                }
                catch
                {
                    ViewBag.erreur = "Verifier les champs !!!";
                    return View();
                }


                // return View();
                db.trajets.Add(trajet1);
                db.SaveChanges();

            }
          



            //trajet1.idCar= ViewBag.trajetsso.

            //trajet trajet1 = new trajet();
            // trajet1.idCar=id;
          


            return RedirectToAction("listTrajet");

        }



        [Route("listTrajet")]
        public ActionResult listTrajet()
        {
            if (Session["Societe"] != null)
            {
                societe so = (societe)Session["Societe"];
                //var trajets = db.trajets.ToList();
                ViewBag.trajets = db.trajets.Where(t => t.car.id_societe == so.id).ToList();
            }
           

            return View();
        }


        [Route("deleteT{id}")]
        public ActionResult deleteT(int id)
        {
            trajet t = db.trajets.Find(id);
            db.trajets.Remove(t);
            db.SaveChanges();

            return RedirectToAction("listTrajet");
        }
        /* 
               [Route("EditT{id}")]

               public ActionResult EditT(int i=0)
               {

                   ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");
                   ViewBag.id_Nbr_place = new SelectList(db.villes.ToList(), "id", "nom");
                   ViewBag.id_type = new SelectList(db.villes.ToList(), "id", "nom");
                   ViewBag.id_description = new SelectList(db.reservations.ToList(), "id");
                   ViewBag.listeville = db.villes.ToList();
                   return View();


               }
         */


        // [Route("EditT{id}")]
        // [HttpPost]

        //  public ActionResult EditT([Bind(Include = "Ville_depart,Ville-arrive,Date_depart,Nmb_heure,idCar")] trajet trajet)
        /*  {
              if (ModelState.IsValid)
              {
                  db.Entry(trajet).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("listTrajet");
              }
              return View(trajet);
          } */






        [Route("EditT/{id}")]
        public ActionResult EditT(int? id)
        {


            ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");
            ViewBag.id_ville_depart = new SelectList(db.villes.ToList(), "id", "nomVille");
            ViewBag.id_ville_arrive = new SelectList(db.villes.ToList(), "id", "nomVille");
            ViewBag.listeville = db.villes.ToList();
            //trajet trajet1 = new trajet();
            trajet trajets = db.trajets.Find(id);
            ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");


            if (trajets == null)
            {
                return RedirectToAction("listTrajet");



            }
            else
            {
                ViewBag.ville_depart = trajets.ville.nomVille;
                ViewBag.ville_arrive = trajets.ville1.nomVille;
                ViewBag.Date_arrivee = trajets.Date_arrive;

            }
            UpdateModel(trajets);
            ViewBag.trajets = trajets;

            db.SaveChanges();
            // db.trajets.Find(trajetx.id).SetType= trajets.GetType;
            return View(trajets);

        }

    }
}