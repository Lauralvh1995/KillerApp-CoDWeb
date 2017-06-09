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
            Read(1);
        }

        public void Add(int userid, Character character)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "INSERT INTO Character (Account_ID, name, concept, look, background, gender, age)" +
                                    "VALUES (@accountid, @name, @concept, @look, @background, @gender, @age";
            command.AddParameterWithValue("accountid", userid);
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
            command.CommandText = "SELECT * FROM [Character] WHERE [account_ID]=@userid;";
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
                        Age = reader.GetInt32(7),
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
                        Health = reader.GetInt32(15),
                        Willpower = reader.GetInt32(16),
                        Integrity = reader.GetInt32(17),
                        Size = reader.GetInt32(18),
                        Speed = reader.GetInt32(19),
                        Defense = reader.GetInt32(20),
                        Armor = reader.GetInt32(21),
                        InitiativeMod = reader.GetInt32(22),
                        Beats = reader.GetInt32(23),
                        Experience = reader.GetInt32(24),
                    };
                    
                    characters.Add(character);
                }
            }
            foreach(Character character in characters)
            {
                for (int i = 1; i < 34; i++)
                {
                    character.Stats.Add(GetStat(character, i));
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

        public void AddStat(Character character, Stat stat)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "INSERT INTO StatCombo (Char_ID, stat_ID, value) VALUES (@characterID, @statID, @value)";
            command.AddParameterWithValue("characterID", character.ID);
            command.AddParameterWithValue("statID", stat.ID);
            command.AddParameterWithValue("value", stat.Value);

            _connector.ExecuteNonQuery(command);
        }

        public void UpdateStat(Character character, Stat stat)
        {
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "UPDATE StatCombo SET Char_ID=@characterID, stat_ID=@statID, value=@value";
            command.AddParameterWithValue("characterID", character.ID);
            command.AddParameterWithValue("statID", stat.ID);
            command.AddParameterWithValue("value", stat.Value);

            _connector.ExecuteNonQuery(command);
        }

        public Stat GetStat(Character character, int id)
        {
            Stat stat = new Stat();
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "SELECT * FROM [StatType] JOIN [Stat] ON StatType.ID = Stat.t_ID JOIN [StatCombo] ON Stat.ID = StatCombo.stat_ID WHERE [stat_ID]=@statid AND [Char_ID]=@charid";
            command.AddParameterWithValue("statid", id);
            command.AddParameterWithValue("charid", character.ID);

            using (IDataReader reader = _connector.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    stat.ID = reader.GetInt32(6);
                    stat.StatType = (StatType)reader.GetInt32(8);
                    stat.Name = reader.GetString(7);
                    stat.DotCost = reader.GetInt32(4);
                    stat.SpecializationEnabled = reader.GetBoolean(5);
                    stat.FactionRequirement = reader.GetString(2);
                    if (reader.GetInt32(11) != 0)
                    {
                        stat.Value = reader.GetInt32(11);
                    }
                    else
                    {
                        stat.Value = reader.GetInt32(3);
                    }
                }
            }

            stat.Requirement = GetRequirements(stat).ToList();
            return stat;
        }

        public List<Requirement> GetRequirements(Stat stat)
        {
            List<Requirement> requirements = new List<Requirement>();
            IDbCommand command = _connector.CreateCommand();
            command.CommandText = "SELECT * FROM [Requirement] WHERE [stat1_ID]=@statid;";
            command.AddParameterWithValue("statid", stat.ID);

            using (IDataReader reader = _connector.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    Requirement requirement = new Requirement()
                    {
                        StatID = reader.GetInt32(1),
                        Value = reader.GetInt32(2),
                        Additive = reader.GetBoolean(3)
                    };
                    requirements.Add(requirement);
                }
            }
            return requirements;
        }
    }
}

