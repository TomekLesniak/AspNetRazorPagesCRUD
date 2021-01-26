using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWeb.Models
{
    public class NewPersonModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime DateOfBirth { get; set; } = DateTime.Today.Date;
        [Required] public bool IsActive { get; set; }
    }
}
