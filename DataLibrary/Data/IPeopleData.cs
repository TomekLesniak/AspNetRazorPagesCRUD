using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IPeopleData
    {
        Task<int> CreatePerson(PersonModel person);
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPersonById(int id);
        Task<int> UpdatePerson(int id, string firstName);
        Task<int> DeletePerson(int id);
    }
}