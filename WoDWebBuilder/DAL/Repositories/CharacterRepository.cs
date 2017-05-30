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
            return null;
        }
        public void Add(Character character)
        {

        }
        public void Refresh()
        {

        }
        public void Update(Character character)
        {

        }
        public void Delete(Character character)
        {

        }
    }
}