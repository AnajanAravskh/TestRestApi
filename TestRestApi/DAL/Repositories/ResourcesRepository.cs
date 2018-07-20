using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResourcesRepository : IRepository<Resource>
    {
        private ResourcesContext context;
        public ResourcesRepository(ResourcesContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(int ID)
        {
            var resource = await context.Resources.FindAsync(ID);
            context.Resources.Remove(resource);
        }

        public IQueryable<Resource> GetAll()
        {
            return context.Resources;
        }

        public async Task<Resource> GetByID(int ID)
        {
            return await context.Resources.FindAsync(ID);
        }

        public Resource Insert(Resource entity)
        {
            return context.Resources.Add(entity).Entity;
        }

        public Resource Update(int ID, Resource entity)
        {
           return context.Resources.Update(entity).Entity;
        }

        public async Task SaveChangesAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
