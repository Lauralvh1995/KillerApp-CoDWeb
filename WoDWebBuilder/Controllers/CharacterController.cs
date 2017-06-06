using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoDWebBuilder.DAL;
using WoDWebBuilder.DAL.Connection;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.Controllers
{
    public class CharacterController : Controller
    {
        List<Character> characters = new List<Character>();
        private IDatabaseConnector _connector;
        private CharacterRepository _repo;
        public CharacterController()
        {
            _connector = new SQLServerConnector();
            _repo = new CharacterRepository(_connector);
        }


        // GET: Character
        public ActionResult Index()
        {
            List<Character> tempCharacters = _repo.GetCharacters().ToList();
            foreach (Character character in tempCharacters)
            {
                if (character.UserID == /*current user id*/1)
                {
                    characters.Add(character);
                }
            }
            return View(characters);
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetCharacterByID(id));
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Character/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               _repo.Add(new Character() { Name = collection["name"],
                                            Gender = collection["gender"],
                                            Age = Convert.ToInt32(collection["age"]),
                                            Background = collection["background"],
                                            Concept = collection["concept"],
                                            Look = collection["look"]
               });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetCharacterByID(id));
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
