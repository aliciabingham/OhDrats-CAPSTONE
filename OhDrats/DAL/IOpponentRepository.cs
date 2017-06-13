using OhDrats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhDrats.Controllers
{
    public interface IOpponentRepository
    {
        void Save(Opponent newOpponent);
        // IEnumerable<Customer> GetAll();
        void Get(Opponent existentOpponent);
    }
}
