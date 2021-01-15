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

        TransportEntitieslast db = new TransportEntitieslast();

    
   
       

        [Route("")]
        public ActionResult Index(client client, societe societe, String login, String password, string hwoIam)
        {

            if (Session["isconnect"] != null && (bool)Session["isconnect"] == true)
            {
                  ViewBag.Client = Session["Client"] ;
            }
            // verification des valeur de connection 
            if (login != null)
            {
                // verification du type de compte avec la variable hwoIam
                if (hwoIam != null && hwoIam.Equals("Client"))
                {
                    client cli = new client();
                    // Recherche dans la table client 
                    cli = db.clients.Where(c => c.login_client == login).FirstOrDefault();
                   if (cli != null)
                    {
                        Session["isconnect"] = true;
                        Session["Client"] = cli;
                        ViewBag.Client = cli;
                        Session["whoIam"] = 1; 
                    }
                    else {
                        System.Diagnostics.Debug.WriteLine("Erreur ! indentifiant");
                    }
                }
                else
                {
                    Session["whoIam"] = 2;
                    societe soc = new societe();
                    // Recherche dans la table client 
                    soc = db.societes.Where(s => s.login_societe == login).FirstOrDefault();
                    if (soc != null)
                    {
                        Session["isconnect"] = true;
                        Session["Societe"] = soc;
                        ViewBag.Societe = soc;
                        Session["whoIam"] = 2;

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Erreur ! indentifiant");
                    }

                }
            }

            if (societe.login_societe != null)
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
            }
            else if (client.login_client != null)
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
            }
            List<ville> listeVille = db.villes.ToList();
            @ViewBag.SlectedView = "Home";
            return View(listeVille);
        }

        [Route("Rechercher")]
        public ActionResult Rechercher(string ville_depart , string ville_arriver , DateTime date_depart , DateTime date_arriver)
        {
            if ( ville_depart != null &&  ville_arriver != null &&  date_depart != null &&  date_arriver != null)
            {
                List<trajet> listeTrajet =  db.trajets.Where(t => t.Date_depart <= date_depart && t.Date_arrive >= date_arriver && t.ville.nomVille == ville_depart && t.ville1.nomVille == ville_arriver).ToList();
                ViewBag.Rechercher = listeTrajet;
                if (listeTrajet.Count == 0)
                {
                    Session["NoOne"] = true;
                }
            }
           
            int id = 200;
            return RedirectToAction("Index" , "offres");
        }


        [Route("listres")]
        public ActionResult listres()
        {
            var reservations = db.reservations.ToList();
            ViewBag.reservations = reservations;

            return View();
        }

        [Route("Deconnection")]
        public ActionResult Deconnection()
        {
            Session.Clear();// vider la session
            System.Diagnostics.Debug.WriteLine((Session["Client"] == null));
            return View("Index");
        }

    }
}