using RaterApp.Models;
using RaterApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaterApp.Controllers
{
    public class RatingProviderController : Controller
    {
        // GET: RatingProvider
        public ActionResult Index()
        {

            if (Session["ds"] == null)
            {
                Session["ds"] = new DataSource();
            }

            var ds = (DataSource)Session["ds"];
            var list = ds.RatingProvidersList;
            //IList<RaterApp.Models.RatingProviderModel> list = new List<RatingProviderModel>();
            /*
            //setup providers
            var provider1  = new RatingProviderModel() { Name = "TIVO", TrustScore = 0.6M, ApiUrl = "http://www.omdbapi.com" };
            var provider2 = new RatingProviderModel() { Name = "IMDB", TrustScore = 0.5M, ApiUrl = "http://www.omdbapi.com" };
            var provider3 = new RatingProviderModel() { Name = "HACK", TrustScore = 0.3M, ApiUrl = "http://www.omdbapi.com" };
            list.Add(provider1);
            list.Add(provider2);
            list.Add(provider3);

            //
            */
            return View(list);
        }

        // GET: RatingProvider/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RatingProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingProvider/Create
        [HttpPost]
        public ActionResult Create(RatingProviderModel newProvider)
        {
            try
            {
                // TODO: Add insert logic here
                var ds = (DataSource)Session["ds"];
                var list = ds.RatingProvidersList;
                //add new ID
                var provider = new RatingProviderModel() { Name = newProvider.Name, TrustScore = newProvider.TrustScore, ApiUrl = newProvider.ApiUrl };
                list.Add(provider);
                Session["ds"] = ds;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingProvider/Edit/5
        public ActionResult Edit(int id)
        {
            var ds = (DataSource)Session["ds"];
            var list = ds.RatingProvidersList;
            RatingProviderModel element = null;
            foreach (var item in list) {
                if (item.id == id)
                {
                    element = item;
                    break;
                } 

            }
            return View(element);
        }

        // POST: RatingProvider/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RatingProviderModel changedElement)
        {
          

            try
            {
                var ds = (DataSource)Session["ds"];
                var list = ds.RatingProvidersList;
                RatingProviderModel element = null;
                foreach (var item in list)
                {
                    if (item.id == id)
                    {
                        element = item;
                        break;
                    }

                }

                element.Name = changedElement.Name;
                element.TrustScore = changedElement.TrustScore;
                element.ApiUrl = changedElement.ApiUrl;
                //list[id] = element;
                //ds.RatingProvidersList = list;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingProvider/Delete/5
        public ActionResult Delete(int id)
        {

            var ds = (DataSource)Session["ds"];
            var list = ds.RatingProvidersList;
            RatingProviderModel element = null;
            foreach (var item in list)
            {
                if (item.id == id)
                {
                    element = item;
                    break;
                }

            }
            return View(element);
        }

        // POST: RatingProvider/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var ds = (DataSource)Session["ds"];
                var list = ds.RatingProvidersList;
                RatingProviderModel element = null;
                foreach (var item in list)
                {
                    if (item.id == id)
                    {
                        element = item;
                        break;
                    }

                }
                list.Remove(element);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
