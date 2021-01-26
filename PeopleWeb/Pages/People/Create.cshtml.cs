using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleWeb.Models;

namespace PeopleWeb.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly IPeopleData _data;
        [BindProperty] public NewPersonModel Person { get; set; }

        public CreateModel(IPeopleData data)
        {
            _data = data;
        }

        public async Task<IActionResult> OnPost()
        {
            var person = new PersonModel
            {
                FirstName = Person.FirstName,
                LastName = Person.LastName,
                DateOfBirth = Person.DateOfBirth,
                IsActive = Person.IsActive
            };
            int personId = await _data.CreatePerson(person);
            return RedirectToPage("./All");
        }
        
        
        public void OnGet()
        {
        }
    }
}
