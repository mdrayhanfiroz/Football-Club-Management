using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayerManagementSystem
{
    public interface IRepository
    {
        void Add(Players player);
        void Update(Players player);
        void Delete(Players player);
        IEnumerable<Players> GetAll();
        Players GetByName(string name);
    }
}
