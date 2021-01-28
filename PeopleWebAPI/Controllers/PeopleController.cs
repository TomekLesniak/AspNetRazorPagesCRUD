using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using PeopleWebAPI.Models;

namespace PeopleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleData _data;

        public PeopleController(IPeopleData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _data.GetPeople();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var person = await _data.GetPersonById(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(PersonModel person)
        {
            var id = await _data.CreatePerson(person);
            return Ok(new {Id = id});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(UpdatePersonModel data)
        {
            if (data.Id == 0)
            {
                return BadRequest();
            }

            await _data.UpdatePerson(data.Id, data.FirstName);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _data.DeletePerson(id);
            return Ok();
        }
        
        
    }
}
