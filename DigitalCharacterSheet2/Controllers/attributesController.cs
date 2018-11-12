using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalCharacterSheet2.Models;

namespace DigitalCharacterSheet2.Controllers
{
    public class attributesController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: attributes
        public ActionResult Index()
        {
            var attributes = db.attributes.Include(a => a.character);
            return View(attributes.ToList());
        }

        // GET: attributes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attribute attribute = db.attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        // GET: attributes/Create
        public ActionResult Create()
        {
            ViewBag.characterName = new SelectList(db.characters, "character_name", "campaign");
            return View();
        }

        // POST: attributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "characterName,attributeName,attributeValue")] attribute attribute)
        {
            if (ModelState.IsValid)
            {
                db.attributes.Add(attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.characterName = new SelectList(db.characters, "character_name", "campaign", attribute.characterName);
            return View(attribute);
        }

        // GET: attributes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attribute attribute = db.attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.characterName = new SelectList(db.characters, "character_name", "campaign", attribute.characterName);
            return View(attribute);
        }

        // POST: attributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "characterName,attributeName,attributeValue")] attribute attribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.characterName = new SelectList(db.characters, "character_name", "campaign", attribute.characterName);
            return View(attribute);
        }

        // GET: attributes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attribute attribute = db.attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        // POST: attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            attribute attribute = db.attributes.Find(id);
            db.attributes.Remove(attribute);
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
