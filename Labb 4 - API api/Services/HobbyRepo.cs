using Labb_4___API;
using Labb_4___API.Data;
using Labb_4___API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4___API_api.Services
{
    public class HobbyRepo : IRepo<Hobby>
    {
        private Labb4DbContext context;

        public HobbyRepo(Labb4DbContext cont)
        {
            context = cont;
        }
        public async Task<Hobby> AddAsync(Hobby newEntity)
        {
            var result = await context.Hobbies.AddAsync(newEntity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Hobby> DeleteAsync(int id)
        {
            var HobbyToDelete = await context.Hobbies.FirstOrDefaultAsync(h => h.ID == id);
            if (HobbyToDelete != null)
            {
                context.Hobbies.Remove(HobbyToDelete);
                await context.SaveChangesAsync();
                return HobbyToDelete;
            }
            return null;
        }

        public async Task<IEnumerable<Hobby>> GetAllAsync()
        {
            return await context.Hobbies.ToListAsync();
        }

        public async Task<Hobby> GetSingleAsync(int id)
        {
            return await context.Hobbies.Include(w => w.WebLinks).FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<Hobby> UpdateAsync(Hobby entity)
        {
            var hobbyToUpdate = await context.Hobbies.FirstOrDefaultAsync(h => h.ID == entity.ID);
            if (hobbyToUpdate != null)
            {
                hobbyToUpdate.HobbyName = entity.HobbyName;
                hobbyToUpdate.Description = entity.Description;
                await context.SaveChangesAsync();
                return hobbyToUpdate;
            }
            return null;
        }
    }
}
