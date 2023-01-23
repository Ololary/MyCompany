using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<Serviceitem> GetServiceItems();
        Serviceitem GetServiceItemById(Guid id);
        void SaveServiceItem(Serviceitem entity);
        void DeleteServiceItem(Guid id);
    }
}
