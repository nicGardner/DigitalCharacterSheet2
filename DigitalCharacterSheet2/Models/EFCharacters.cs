using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalCharacterSheet2.Models
{
    public class EFCharacters : ICharactersMock
    {

        private DBConnect db = new DBConnect();

        public IQueryable<character> Characters { get { return db.characters; } }

        public IQueryable<attribute> Attributes { get { return db.attributes; } }

        public void Delete(character character)
        {
            db.characters.Remove(character);
            db.SaveChanges();
        }

        public character SaveEdit(character character)
        {
            //if(character.character_name == null || character.character_name == "" || character.character_name ==" ")
            //{
            //    db.characters.Add(character);
            //}
            //else
            //{
            //    db.Entry(character).State = System.Data.Entity.EntityState.Modified;
            //}
            //db.SaveChanges();
            //return character;
            db.Entry(character).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return character;
        }   
        public character SaveNew(character character)
        {
            db.characters.Add(character);
            db.SaveChanges();
            return character;
        }
    }
}