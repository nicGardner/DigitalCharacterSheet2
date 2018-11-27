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
    public class charactersController : Controller
    {

        private ICharactersMock db;
        public charactersController()
        {
            this.db = new EFCharacters();
        }

        public charactersController(ICharactersMock charactersMock)
        {
            this.db = charactersMock;
        }

        // GET: characters
        public ActionResult Index()
        {
            var characters = db.Characters;
            return View("Index", characters.ToList());
        }

        // GET: characters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //character character = db.characters.Find(id);
            character character = db.Characters.SingleOrDefault(a => a.character_name == id);
            if (character == null)
            {
                return View("Error");
            }
            return View("Details", character);
        }

        // GET: characters/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "character_name,campaign,advancement_points,plot_points")] character character)
        {
            if (ModelState.IsValid)
            {
                //db.characters.Add(character);
                //db.SaveChanges();
                db.SaveNew(character);
                return RedirectToAction("Index");
            }

            return View(character);
        }

        //// GET: characters/CreateAttribute
        //[Authorize]
        //public ActionResult CreateAttribute(string id)
        //{
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    //character character = db.characters.Find(id);
        //    character character = db.Characters.SingleOrDefault(a => a.character_name == id);
        //    if (character == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    attribute att = new attribute();
        //    att.characterName = character.character_name;
        //    att.attributeName = " ";
        //    att.attributeValue = 0;
        //    ViewBag.id = character.character_name;
        //    return View("CreateAttribute", att);
        //}

        //// POST: characters/CreateAttribute
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult CreateAttribute([Bind(Include = "characterName,attributeName,attributeValue")] attribute attribute)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.attributes.Add(attribute);
        //        db.SaveChanges();
        //        return RedirectToAction("Details", new { id = attribute.characterName });
        //    }

        //    return View(attribute);
        //}

        //// GET: characters/Edit/5
        //[Authorize]
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    character character = db.characters.Find(id);
        //    if (character == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(character);
        //}

        //// POST: characters/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Edit([Bind(Include = "character_name,campaign,advancement_points,plot_points")] character character)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(character).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(character);
        //}



        //// GET: characters/EditAttributes/5
        //[Authorize]
        //public ActionResult EditAttributes(string id, string id2)
        //{
        //    if (id == null || id2 == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    attribute attribute = db.attributes.Find(id, id2);
        //    //character character = db.characters.Find(id);
        //    if (attribute == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(attribute);
        //}

        //// POST: characters/EditAttributes/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult EditAttributes([Bind(Include = "characterName,attributeName,attributeValue")] attribute attribute)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(attribute).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(attribute);
        //}



        //// GET: characters/Delete/5
        //[Authorize]
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    character character = db.characters.Find(id);
        //    if (character == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(character);
        //}

        //// POST: characters/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    character character = db.characters.Find(id);
        //    db.characters.Remove(character);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
