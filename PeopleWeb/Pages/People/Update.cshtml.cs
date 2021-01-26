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
    public class UpdateModel : PageModel
    {
        private readonly IPeopleData _data;
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        [BindProperty] public UpdatePersonModel UpdatePerson { get; set; }
        
        public PersonModel FullPerson { get; set; }
        
        public UpdateModel(IPeopleData data)
        {
            _data = data;
        }
        
        public async Task<IActionResult> OnGet()
        {
            FullPerson = await _data.GetPersonById(Id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            await _data.UpdatePerson(UpdatePerson.Id, UpdatePerson.FirstName);
            return RedirectToPage("./All");
        }
    }
}
