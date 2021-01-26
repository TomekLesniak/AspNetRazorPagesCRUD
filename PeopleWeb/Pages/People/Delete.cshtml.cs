using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PeopleWeb.Pages.People
{
    public class DeleteModel : PageModel
    {
        private readonly IPeopleData _data;

        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        [BindProperty] public PersonModel Person { get; set; }

        public DeleteModel(IPeopleData data)
        {
            _data = data;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _data.DeletePerson(Person.Id);
            return RedirectToPage("./All");
        }
        
        public async Task<IActionResult> OnGet()
        {
            Person = await _data.GetPersonById(Id);
            return Page();
        }
    }
}
