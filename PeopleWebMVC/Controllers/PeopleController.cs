using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using PeopleWebMVC.Models;

namespace PeopleWebMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleData _data;

        public PeopleController(IPeopleData data)
        {
            _data = data;
        }
        
        public async Task<IActionResult> Index()
        {
            var people = await _data.GetPeople();
            return View(people);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _data.GetPersonById(id);
            var person = new UpdatePersonModel
            {
                Id = id,
                FirstName = data.FirstName
            };
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePersonModel person)
        {
            await _data.UpdatePerson(person.Id, person.FirstName);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var person = new NewPersonModel();
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPersonModel person)
        {
            var fullPersonModel = new PersonModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                IsActive = person.IsActive
            };
            int id = await _data.CreatePerson(fullPersonModel);
            return RedirectToAction("Edit", new {id});
        }

        public async Task<IActionResult> Delete(int id)
        {
            var person = await _data.GetPersonById(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PersonModel person)
        {
            await _data.DeletePerson(person.Id);
            return RedirectToAction("Index");
        }
    }
}
