using OhDrats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhDrats.DAL
{
    public interface IBattleRepository
    {
        void Save(Battle newBattle);
        List<Battle> GetAll(string userId);
    }
}
