using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.DAL
{
    public class CharacterContext : IContext<Character>
    {
        private readonly IDatabaseConnector _connector;

        public CharacterContext(IDatabaseConnector connector)
        {
            _connector = connector;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Character> Read(int userid)
        {
            List<Character> characters = new List<Character>();

            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "SELECT * FROM [Character] WHERE [UserID]=@userid;";
            command.AddParameterWithValue("userid", userid);

            using (IDataReader reader = _connector.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Character character = new Character()
                    {
                        ID = reader.GetInt32(0),
                        UserID = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        Concept = reader.GetString(4),
                        Age  = reader.GetInt32(8),
                        Background = reader.GetString(6),
                        Look = reader.GetString(5),
                        Gender = reader.GetString(7)
                    };

                    characters.Add(character);
                }
            }
            return characters;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void AddKit()
        {
            //TODO: Query voor kit toevoegen
        }
    }
}