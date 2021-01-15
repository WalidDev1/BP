using Projet_Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Transport.Controllers
{
    public class offresController : Controller
    {
        TransportEntitieslast db = new TransportEntitieslast();

        // GET: offres
        
        public ActionResult Index()
        {
            List<trajet> listeTrajet = ViewBag.Rechercher;
            if (listeTrajet != null)
            {
                ViewBag.listeOffres = ViewBag.Rechercher;
                System.Diagnostics.Debug.WriteLine("yes");
            }
            else if (Session["NoOne"] != null && (bool)Session["NoOne"] == true)
            {
                ViewBag.message = "aucune correspondance trouver";
                Session["NoOne"] = false ;
            }
            else
            {
                ViewBag.listeOffres = db.trajets;
            }
           
            if (Session["Client"] != null)
            {
                client clientS = (client)Session["Client"];
                ViewBag.Reservation = clientS.reservations;
            }
            

           /* if (id_trajet != -1)
            {
                System.Diagnostics.Debug.WriteLine(db.trajets.Where( t => t.id == id_trajet).FirstOrDefault().ville) ;
            }
*/
            return View();
        }

        [Route("Reserver/{id}")]
        public ActionResult Reserver(int id)
        {
            
            if (Session["Client"] != null)
            {
            reservation res = new reservation();
            res.idTrajet = id;
            client cc = (client)Session["Client"];
            res.idClient = cc.id;
            res.date_reservation = DateTime.Now;
            UpdateModel(res);
            db.reservations.Add(res);
            db.SaveChanges();
            
           
                client clientS = (client)Session["Client"];
                clientS.reservations.Add(res);
                ViewBag.Reservation = clientS.reservations;
            }
            if (ViewBag.Rechercher != null)
            {
                ViewBag.listeOffres = ViewBag.Rechercher;
            }
            else
            {
                ViewBag.listeOffres = db.trajets;
            }
            return View("index");
        }

        [Route("Annuler/{id}")]
        public ActionResult Annuler(int id)
        {
           
            if (Session["Client"] != null)
            {
            client cc = (client)Session["Client"];
            reservation res =  db.reservations.Find(cc.reservations.Where(r => r.idTrajet == id).FirstOrDefault().id);
            db.reservations.Remove(res);
            cc.reservations.Remove(res);
            
            db.SaveChanges();
           
                ViewBag.Reservation = cc.reservations;
            }
            if (ViewBag.Rechercher != null)
            {
                ViewBag.listeOffres = ViewBag.Rechercher;
            }
            else
            {
                ViewBag.listeOffres = db.trajets;
            }
            return View("index");
        }
    }
}