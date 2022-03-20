using Labb_4___API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4___API.Services
{
    internal class PersonRepo : IRepo<Person>
    {
        private Labb4DbContext context;

        public PersonRepo(Labb4DbContext cont)
        {
            context = cont;
        }
        public async Task<Person> AddAsync(Person newEntity)
        {
            var result = await context.Persons.AddAsync(newEntity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> DeleteAsync(int id)
        {
            var PersonToDelete = await context.Persons.FirstOrDefaultAsync(p => p.ID == id);
            if (PersonToDelete != null)
            {
                context.Persons.Remove(PersonToDelete);
                await context.SaveChangesAsync();
                return PersonToDelete;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person> GetSingleAsync(int id)
        {
            return await context.Persons.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            var personToUpdate = await context.Persons.FirstOrDefaultAsync(p => p.ID == entity.ID);
            if (personToUpdate != null)
            {
                personToUpdate.FName = entity.FName;
                personToUpdate.LName = entity.LName;
                personToUpdate.PhoneNum = entity.PhoneNum;
                personToUpdate.Email = entity.Email;
                await context.SaveChangesAsync();
                return personToUpdate;
            }
            return null;
        }
    }
}
