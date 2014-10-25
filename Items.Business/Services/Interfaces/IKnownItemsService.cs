using MyStock.Business.DAL.Entities;

namespace MyStock.Business.Services.Interfaces
{
    public interface IKnownItemsService : IBaseService<Item>
    {
        Item Get(string name);
        bool Remove(string name);
    }
}