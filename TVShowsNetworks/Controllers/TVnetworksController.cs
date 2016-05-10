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
    public class TVnetworksController : Controller
    {
        private TVShowsNetworksEntities db = new TVShowsNetworksEntities();

        // GET: TVnetworks
        public ActionResult Index(string search)/*need to fix this*/
        {
            if(search != null)
            {
                return View(db.TVnetworks.Where(x => x.Name.StartsWith(search)).ToList());
            }
            else
            {
                return View(db.TVnetworks.ToList());
            }
            
        }

        // GET: TVnetworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVnetwork tVnetwork = db.TVnetworks.Find(id);
            if (tVnetwork == null)
            {
                return HttpNotFound();
            }
            return View(tVnetwork);
        }

        // GET: TVnetworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVnetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NetworkID,Name,Logo")] TVnetwork tVnetwork)
        {
            if (ModelState.IsValid)
            {
                db.TVnetworks.Add(tVnetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tVnetwork);
        }

        // GET: TVnetworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVnetwork tVnetwork = db.TVnetworks.Find(id);
            if (tVnetwork == null)
            {
                return HttpNotFound();
            }
            return View(tVnetwork);
        }

        // POST: TVnetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NetworkID,Name,Logo")] TVnetwork tVnetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVnetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tVnetwork);
        }

        // GET: TVnetworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVnetwork tVnetwork = db.TVnetworks.Find(id);
            if (tVnetwork == null)
            {
                return HttpNotFound();
            }
            return View(tVnetwork);
        }

        // POST: TVnetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVnetwork tVnetwork = db.TVnetworks.Find(id);
            db.TVnetworks.Remove(tVnetwork);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
