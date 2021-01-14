using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Projet_Transport.Models;

namespace Projet_Transport.Controllers
{
    public class HomeController : Controller
    {


        TransportBDEntities3 db = new TransportBDEntities3();
        public string[] listeville = {
            "Volvo",
            "BMW",
            "Ford",
            "Mazda"
        };


        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
   
       

        [HttpPost]
        [Route("")]
        public ActionResult Index(client client, societe societe)
        {
            reservation res1 = new reservation();
            try
            { UpdateModel(res1); }
            catch
            {
                ViewBag.erreur = "Verifier les champs !!!";
                return View();
            }
            //return View();
            db.reservations.Add(res1);
            db.SaveChanges();

            if ( societe.adresse != null )
            {
                societe s = new societe();
                try
                {
                    //insertion des donne recus dans notre variable
                    UpdateModel(s);
                    db.societes.Add(s);
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("daz1");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return View("Index", new societe());
            }
      
            else if ( societe.adresse == null )
            {

                client c = new client();
                try
                {
                    //insertion des donne recus dans notre variable
                    UpdateModel(c);
                    db.clients.Add(c);
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("daz2");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return View("Index", new client());
            }
            List<ville> listeVille = db.villes.ToList();
            @ViewBag.SlectedView = "Home";
            return View(listeVille);
        }
        [Route("listres")]
        public ActionResult listres()
        {
            var reservations = db.reservations.ToList();
            ViewBag.reservations = reservations;

            return View();
        }

      

    }
}