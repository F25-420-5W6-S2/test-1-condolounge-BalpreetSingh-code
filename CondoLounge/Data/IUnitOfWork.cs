using CondoLounge.Data.Interfaces;
using CondoLounge.Data.Repositories;

namespace CondoLounge.Data
{
    public interface IUnitOfWork : IDisposable
    {        
        T GetRepository<T>() where T : class;
        //DutchProductRepository ProductRepository { get; }
        //DutchOrderRepository OrderRepository { get; }
        //DutchOrderItemRepository OrderItemRepository { get; }
    }
}