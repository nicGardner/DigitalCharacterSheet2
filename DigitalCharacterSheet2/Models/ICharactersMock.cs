using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCharacterSheet2.Models
{
    public interface ICharactersMock
    {
        IQueryable<character> Characters { get; }
        IQueryable<attribute> Attributes { get; }

        character SaveNew(character character);
        character SaveEdit(character character);
        attribute SaveAttribute(attribute attribute);
        attribute SaveEditAttribute(attribute attribute);
        void Delete(character character);

    }
}
