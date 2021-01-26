using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.Database;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDb _db;
        private string _connectionStringName = "Default";

        public PeopleData(ISqlDb db)
        {
            _db = db;
        }

        public async Task<int> CreatePerson(PersonModel person)
        {
            var p = new DynamicParameters();
            p.Add("FirstName", person.FirstName);
            p.Add("LastName", person.LastName);
            p.Add("DateOfBirth", person.DateOfBirth);
            p.Add("IsActive", person.IsActive);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("dbo.spPeople_Create", p, _connectionStringName);

            return p.Get<int>("Id");
        }

        public Task<List<PersonModel>> GetPeople()
        {
            return _db.LoadData<PersonModel, dynamic>("dbo.spPeople_GetAll", new {}, _connectionStringName);
        }

        public async Task<PersonModel> GetPersonById(int id)
        {
            var output = await _db.LoadData<PersonModel, dynamic>("dbo.spPeople_GetById", new {Id = id},
                _connectionStringName);
            return output.FirstOrDefault();
        }

        public Task<int> UpdatePerson(int id, string firstName)
        {
            return  _db.SaveData("dbo.spPeople_UpdateFirstName", new {Id = id, FirstName = firstName}, _connectionStringName);
        }

        public Task<int> DeletePerson(int id)
        {
            return _db.SaveData("dbo.spPeople_Delete", new {Id = id}, _connectionStringName);
        }
    }
}
