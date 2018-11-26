using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalCharacterSheet2.Models
{
    public class EFCharacters : ICharactersMock
    {

        private DBConnect db = new DBConnect();

        public IQueryable<character> Characters => throw new NotImplementedException();

        public IQueryable<attribute> Attributes => throw new NotImplementedException();

        public void Delete(character character)
        {
            db.characters.Remove(character);
            db.SaveChanges();
        }

        public character Save(character character)
        {
            if(character.character_name == null)
            {
                db.characters.Add(character);
            }
            else
            {
                db.Entry(character).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return character;
        }
    }
}