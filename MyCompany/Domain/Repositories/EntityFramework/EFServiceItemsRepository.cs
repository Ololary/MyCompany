using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Serviceitem> GetServiceItems()
        {
            return context.Serviceitems;
        }

        public Serviceitem GetServiceItemById(Guid id)
        {
            return context.Serviceitems.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItem(Serviceitem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {
            context.Serviceitems.Remove(new Serviceitem() { Id = id });
            context.SaveChanges();
        }
    }
}
