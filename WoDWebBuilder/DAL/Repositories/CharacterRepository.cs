﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WoDWebBuilder.DAL;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.DAL
{
    public class CharacterRepository : IRepository<Character>
    {
        public List<Character> Characters { get; set; }
        private readonly CharacterContext _context;
        public CharacterRepository(IDatabaseConnector connector)
        {
            Characters = new List<Character>();
            _context = new CharacterContext(connector);
            Characters = _context.Read(1);
        }
        public IEnumerable<Character> GetCharacters()
        {
            return Characters;
        }

        public Character GetCharacterByID(int characterID)
        {
            foreach (Character character in Characters)
            {
                if (character.ID == characterID)
                {
                    return character;
                }
            }
            throw new Exception("No character found.");
        }
        public void Add(Character character)
        {
            _context.Add(character.UserID, character);
            Characters.Add(character);
        }

        public void AddKit(Character character)
        {
            _context.AddKit(character, "Vampire Hunting");
        }
        public void Refresh()
        {
            _context.Read(1);
        }
        public void Update(Character character)
        {
            _context.Update(character);
        }
        public void Delete(Character character)
        {
            _context.Delete(character);
            Characters.Remove(character);
        }
    }
}