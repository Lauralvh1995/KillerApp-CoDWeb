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

        public void Add(int userid, Character character)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "INSERT INTO Character (AccountID, name, concept, look, background, gender, age)"+
                                    "VALUES (@userid, @name, @concept, @look, @background, @gender, @age";
            command.AddParameterWithValue("userid", userid);
            command.AddParameterWithValue("name", character.Name);
            command.AddParameterWithValue("concept", character.Concept);
            command.AddParameterWithValue("look", character.Look);
            command.AddParameterWithValue("background", character.Background);
            command.AddParameterWithValue("gender", character.Gender);
            command.AddParameterWithValue("age", character.Age);

            _connector.ExecuteNonQuery(command);
        }

        public void Delete(Character character)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "DELETE FROM [Character] WHERE ID=@ID;";
            command.AddParameterWithValue("ID", character.ID);

            _connector.ExecuteNonQuery(command);
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
                        Concept = reader.GetString(3),
                        Age  = reader.GetInt32(7),
                        Background = reader.GetString(5),
                        Look = reader.GetString(4),
                        Gender = reader.GetString(6),
                        Faction = reader.GetString(8),
                        Virtue = reader.GetString(9),
                        Vice = reader.GetString(10),
                        Aspiration1 = reader.GetString(11),
                        Aspiration2 = reader.GetString(12),
                        Aspiration3 = reader.GetString(13),
                        Condition = reader.GetString(14),
                        Health = reader.GetInt32(14),
                        Willpower = reader.GetInt32(15),
                        Integrity = reader.GetInt32(16),
                        Size = reader.GetInt32(17),
                        Speed = reader.GetInt32(18),
                        Defense = reader.GetInt32(19),
                        Armor = reader.GetInt32(20),
                        InitiativeMod = reader.GetInt32(21),
                        Beats = reader.GetInt32(22),
                        Experience = reader.GetInt32(23),
                    };

                    characters.Add(character);
                }
            }
            return characters;
        }

        public void Update(Character character)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "UPDATE Character SET Name=@name, Concept=@concept, Look=@look, Background=@background, Gender=@gender, Age=@age";
            command.AddParameterWithValue("name", character.Name);
            command.AddParameterWithValue("concept", character.Concept);
            command.AddParameterWithValue("look", character.Look);
            command.AddParameterWithValue("background", character.Background);
            command.AddParameterWithValue("gender", character.Gender);
            command.AddParameterWithValue("age", character.Age);

            _connector.ExecuteNonQuery(command);
        }

        public void AddKit(Character character, string kitName)
        {
            //TODO: Query voor kit toevoegen
        }
    }
}