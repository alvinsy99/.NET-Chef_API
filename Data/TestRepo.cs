using System;
using System.Collections.Generic;
using ChefAPI.Data;
using ChefAPI.Models;

namespace ChefAPI.Data
{
    public class TestRepo : I_Chef
    {
        public void AddChef(Chef chef)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chef> GetAllChefs()
        {
            var chefs = new List<Chef>
            {
                new Chef { Id = 0, Name = "Josehp", Specialise = "Italian Food", Experience = 2.5  },
                new Chef { Id = 1, Name = "Michael", Specialise = "French", Experience = 1.0 },
                new Chef { Id = 2, Name = "Mary", Specialise = "Russian", Experience = 0 }
            };

            return chefs;
        }

        public Chef GetChefById(int id)
        {
            return new Chef { Id = 0, Name = "Josehp", Specialise = "Italian", Experience = 2.5  };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateChef(Chef chef)
        {
            throw new NotImplementedException();
        }
    }
}
