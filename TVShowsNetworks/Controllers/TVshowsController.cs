using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TVShowsNetworks.Models;

namespace TVShowsNetworks.Controllers
{
    public class TVshowsController : Controller
    {
        private TVShowsNetworksEntities db = new TVShowsNetworksEntities();

        // GET: TVshows
        public ActionResult Index()
        {
            var tVshows = db.TVshows.Include(t => t.TVnetwork);
            return View(tVshows.ToList());
        }

        // GET: TVshows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVshow tVshow = db.TVshows.Find(id);
            if (tVshow == null)
            {
                return HttpNotFound();
            }
            return View(tVshow);
        }

        // GET: TVshows/Create
        public ActionResult Create()
        {
            ViewBag.NetworkID = new SelectList(db.TVnetworks, "NetworkID", "Name");
            return View();
        }

        // POST: TVshows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,NetworkID,Title,Length,Genre")] TVshow tVshow)
        {
            if (ModelState.IsValid)
            {
                db.TVshows.Add(tVshow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NetworkID = new SelectList(db.TVnetworks, "NetworkID", "Name", tVshow.NetworkID);
            return View(tVshow);
        }

        // GET: TVshows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVshow tVshow = db.TVshows.Find(id);
            if (tVshow == null)
            {
                return HttpNotFound();
            }
            ViewBag.NetworkID = new SelectList(db.TVnetworks, "NetworkID", "Name", tVshow.NetworkID);
            return View(tVshow);
        }

        // POST: TVshows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,NetworkID,Title,Length,Genre")] TVshow tVshow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NetworkID = new SelectList(db.TVnetworks, "NetworkID", "Name", tVshow.NetworkID);
            return View(tVshow);
        }

        // GET: TVshows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVshow tVshow = db.TVshows.Find(id);
            if (tVshow == null)
            {
                return HttpNotFound();
            }
            return View(tVshow);
        }

        // POST: TVshows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVshow tVshow = db.TVshows.Find(id);
            db.TVshows.Remove(tVshow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*method for LINQ search*/
        /*
        public ActionResult ShowsTitle()
        {
            var linq = db.TVshows.Where(Title); 
            return View(linq.ToList()); 
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
