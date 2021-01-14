using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Projet_Transport.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet_Transport.Controllers
{
    public class CarController : Controller
        
    {

        TransportBDEntities3 db = new TransportBDEntities3();

        [Route("AddCar")]
        public ActionResult AddCar(int z = 0)
        {


            return View();
        }
      
        [Route("AddCar")]
        [HttpPost]
        public ActionResult AddCar()
        {

             car testcar = new car();
                 try
            {

                UpdateModel(testcar);

            }
            catch
            {
                ViewBag.erreur = "Verifier les champs !!!";
                return View();
            }

           
            //return View();
            db.cars.Add(testcar);
            db.SaveChanges();
            return RedirectToAction("listcar");

        }
        

        public ActionResult listcar()
        {
            var cars = db.cars.ToList();
            ViewBag.cars = cars;

            return View();
        }

        [Route("deleteC{id}")]
        public ActionResult deleteC(int id)
        {
                car c = db.cars.Find(id);
                db.cars.Remove(c);
                db.SaveChanges();
           
            return RedirectToAction("listcar");
        }


        [Route("EditC/{id}")]
        public ActionResult EditC(int? id)
        {
            car cars = db.cars.Find(id);

            if (cars == null)
            {
                return RedirectToAction("listcar");

            }
            UpdateModel(cars);
            ViewBag.cars = cars;

            db.SaveChanges();
            // db.trajets.Find(trajetx.id).SetType= trajets.GetType;
            return View(cars);
        }


    }
}