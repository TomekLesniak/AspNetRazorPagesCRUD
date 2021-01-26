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
    public class AllModel : PageModel
    {
        private readonly IPeopleData _data;
        [BindProperty] public List<PersonModel> People { get; set; }

        public AllModel(IPeopleData data)
        {
            _data = data;
        }

        public async Task<IActionResult> OnGet()
        {
            People = await _data.GetPeople();
            return Page();
        }
    }
}
