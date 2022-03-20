using Labb_4___API.Data;
using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labb_4___API_api.Services
{
    public class WebLinkRepo : IRepo<WebLink>
    {
        private Labb4DbContext context;

        public WebLinkRepo(Labb4DbContext cont)
        {
            context = cont;
        }
        public async Task<WebLink> AddAsync(WebLink newEntity)
        {
            var result = await context.WebLinks.AddAsync(newEntity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<WebLink> DeleteAsync(int id)
        {
            var webLinkToDelete = await context.WebLinks.FirstOrDefaultAsync(h => h.ID == id);
            if (webLinkToDelete != null)
            {
                context.WebLinks.Remove(webLinkToDelete);
                await context.SaveChangesAsync();
                return webLinkToDelete;
            }
            return null;
        }

        public async Task<IEnumerable<WebLink>> GetAllAsync()
        {
            return await context.WebLinks.ToListAsync();
        }

        public async Task<WebLink> GetSingleAsync(int id)
        {
            return await context.WebLinks.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<WebLink> UpdateAsync(WebLink entity)
        {
            var webLinkToUpdate = await context.WebLinks.FirstOrDefaultAsync(h => h.ID == entity.ID);
            if (webLinkToUpdate != null)
            {
                webLinkToUpdate.Url = entity.Url;
                await context.SaveChangesAsync();
                return webLinkToUpdate;
            }
            return null;
        }
    }
}
