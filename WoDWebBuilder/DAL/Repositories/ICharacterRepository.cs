using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.DAL
{
    interface ICharacterRepository : IRepository
    {
        IEnumerable<Character> GetCharacters();
        Character GetCharacterByID(int characterID);
        void Add(Character character);
        void Update(Character character);
        void Delete(Character character);
        void Save();
    }
}
