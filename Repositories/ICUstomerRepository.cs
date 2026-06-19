using System.Collections.Generic;
using PremiumLivingSystem.Models;

namespace PremiumLivingSystem.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetById(int customerId);
        List<Customer> GetAll();
        bool Add(Customer customer);
        bool Update(Customer customer);
        bool Delete(int customerId);
    }
}