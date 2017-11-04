using RaterApp.Logic;
using RaterApp.Models;
using RaterApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaterApp.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            if (Session["ds"] == null)
            {
                Session["ds"] = new DataSource();
            }

            var ds = (DataSource)Session["ds"];
            var ratingList = ds.RatingList;
            var ratingProvidersList = ds.RatingProvidersList;

            Helpers.ProcessRatings(ratingProvidersList, ratingList);

            ratingList = ratingList.OrderByDescending(x => x.Rating).ToList();

            /*
            IList<RaterApp.Models.RatingModel> list = new List<RatingModel>();

            var ratingModel1 = new RatingModel() { MovieName = "Spiderman", Rating = 7.3M, BroadcastTime = new DateTime(2017, 11, 4, 8, 15, 0) };
            var ratingModel2 = new RatingModel() { MovieName = "Batman", Rating = 6.5M, BroadcastTime = new DateTime(2017, 11, 4, 8, 30, 0) };
            var ratingModel3 = new RatingModel() { MovieName = "Superman", Rating = 5.9M, BroadcastTime = new DateTime(2017,11, 4, 8, 45, 0) };

            
            list.Add(ratingModel1);
            list.Add(ratingModel2);
            list.Add(ratingModel3);
            */

            return View(ratingList);
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
