using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using OhDrats.Models;
using System.Data;
using OhDrats.Controllers;
using WebApplication3.Models;

namespace OhDrats.Controllers
{
    public class OpponentRepository : IOpponentRepository
    {
        readonly IDbConnection _dbConnection;

        public OpponentRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Opponent newOpponent)
        {
            var sql = @"Insert into Opponent(Name)
                        Values(@Name)";

            _dbConnection.Execute(sql, newOpponent);
        }

        public void Get(Opponent existentOpponent)
        {
            var sql = @"Select Name from Opponent";

            _dbConnection.Execute(sql, existentOpponent);

}
    }
}