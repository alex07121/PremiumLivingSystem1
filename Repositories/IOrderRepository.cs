using System.Collections.Generic;
using PremiumLivingSystem.Models;

namespace PremiumLivingSystem.Repositories
{
    public interface IOrderRepository
    {
        Order GetById(int orderId);
        List<Order> GetByCustomerId(int customerId);
        int Create(Order order);
        bool Update(Order order);
        bool UpdateStatus(int orderId, string status);
    }
}