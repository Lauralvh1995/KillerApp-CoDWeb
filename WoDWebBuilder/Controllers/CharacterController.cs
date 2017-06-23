using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            CheckCharacters();
            return View(characters);
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_repo.GetCharacterByID(id));
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
            Index();
            return View("Index", characters);
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
                    model.UserID = 1;
                    _repo.Add(model);
                }
                CheckCharacters();
                return View("Index", characters);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                CheckCharacters();

                return View("Index", characters);
            }
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetCharacterByID(id));
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(Character model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Delete(model);
                }
                CheckCharacters();
                return View("Index", characters);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                CheckCharacters();

                return View("Index", characters);
            }
        }

        [HttpPost]
        public ActionResult Details(Character model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.AddKit(model);
                    model.UserID = 1;
                }
                CheckCharacters();
                return View("Index", characters);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                CheckCharacters();

                return View("Index", characters);
            }
        }

        public void CheckCharacters()
        {
            List<Character> tempCharacters = _repo.GetCharacters().ToList();
            foreach (Character character in tempCharacters)
            {
                if (character.UserID == 1)
                {
                    characters.Add(character);
                }
            }
        }
    }
}
