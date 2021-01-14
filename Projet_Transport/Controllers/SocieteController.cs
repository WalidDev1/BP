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
        TransportBDEntities3 db = new TransportBDEntities3();

        [Route("searsh")]
        public ActionResult searsh()
        {
            return View();
        }

        [Route("AddTrajet")]
        public ActionResult AddTrajet(int j = 0)
        {
            ViewBag.idCar = new SelectList(db.cars.ToList(), "id", "type");
            ViewBag.id_Nbr_place = new SelectList(db.villes.ToList(), "id", "nom");
            ViewBag.id_type = new SelectList(db.villes.ToList(), "id", "nom");
            ViewBag.id_description = new SelectList(db.reservations.ToList(), "id");
            return View();
        }



        [Route("AddTrajet")]
        [HttpPost]
        public ActionResult AddTrajet()
        {

            trajet trajet1 = new trajet();
            try
            {

                UpdateModel(trajet1);

            }
            catch
            {
                ViewBag.erreur = "Verifier les champs !!!";
                return View();
            }


            //return View();
            db.trajets.Add(trajet1);
            db.SaveChanges();
            return RedirectToAction("listTrajet");

        }
        [Route("listTrajet")]
        public ActionResult listTrajet()
        {
            var trajets = db.trajets.ToList();
            ViewBag.trajets = trajets;

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

        [Route("bbEditT{id}")]
        [HttpPost]
        public ActionResult bbEditT(int id)
        {

            var trajettoedit = db.trajets.Find(id);
              UpdateModel(trajettoedit, "",
               new string[] { "Ville_depart", "Ville_arrive", "Date_depart","Nbr_heure","Categorie" });

            db.SaveChanges();

            return RedirectToAction("listTrajet");

           
        }



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
            trajet trajets = db.trajets.Find(id);
           

            if (trajets == null)
            {
                return RedirectToAction("listTrajet");

            }
            UpdateModel(trajets);
            ViewBag.trajets = trajets;

            db.SaveChanges();
            // db.trajets.Find(trajetx.id).SetType= trajets.GetType;
            return View(trajets);
        }

    }
}