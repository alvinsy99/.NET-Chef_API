using System.Collections.Generic;
using ChefAPI.Models;

namespace ChefAPI.Data
{
    public interface I_Chef
    {
        bool SaveChanges();

        IEnumerable<Chef> GetAllChefs();
        Chef GetChefById(int id);
        void AddChef(Chef chef);
        void UpdateChef(Chef chef);
    }
}