using System;
using System.Collections.Generic;

namespace Items.Business.Services.Interfaces
{
    public interface IService<T> : IDisposable
    {
        T Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Update(T updatedItem);
        bool Remove(int id);
        bool Any(int id);
    }
}