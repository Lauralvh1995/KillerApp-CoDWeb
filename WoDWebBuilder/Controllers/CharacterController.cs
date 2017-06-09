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
                if (character.UserID == 1)
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
        public ActionResult Create(Character model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Add(model);

                    return RedirectToAction("Index");
                }
                return View();
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
                _repo.GetCharacterByID(id).Age = Convert.ToInt32(collection["Age"]);
                _repo.GetCharacterByID(id).Background = collection["Background"];
                _repo.Update(_repo.GetCharacterByID(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
