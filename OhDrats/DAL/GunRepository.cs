using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhDrats.Models;
using System.Data;
using Dapper;

namespace OhDrats.DAL
{
    public class GunRepository : IGunRepository
    {
        readonly IDbConnection _dbConnection;

        public GunRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Gun newGun)
        {
            var sql = @"Insert into Gun(GunName, AmountOfAmmo)
                        Values(@GunName, @AmountOfAmmo)";

            _dbConnection.Execute(sql, newGun);
        }
    }
}
