using System;
using System.Collections.Generic;
using System.Linq;
using ChefAPI.Models;

namespace ChefAPI.Data
{
    public class ChefRepo : I_Chef
    {
        private readonly ChefContext _DBmodel;

        public ChefRepo(ChefContext DBmodel)
        {
            _DBmodel = DBmodel;
        }

        public void AddChef(Chef chef)
        {
            if (chef == null)
            {
                throw new ArgumentNullException(nameof(chef));
            }
            _DBmodel.Chefs.Add(chef);
        }

        public IEnumerable<Chef> GetAllChefs()
        {
            return _DBmodel.Chefs.ToList();
        }

        public Chef GetChefById(int id)
        {
            return _DBmodel.Chefs.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_DBmodel.SaveChanges() > 0);
        }

        public void UpdateChef(Chef chef)
        {
            //nothing
        }
    }
}