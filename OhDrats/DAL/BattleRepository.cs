using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OhDrats.Models;
using Dapper;

namespace OhDrats.DAL
{
    public class BattleRepository : IBattleRepository
    {

            readonly IDbConnection _dbConnection;

            public BattleRepository(IDbConnection connection)
            {
                _dbConnection = connection;
            }

        public List<Battle> GetAll(string userId)
        {
            var sql = @"Select * from Battle
                        Where UserId = @userId";

            return _dbConnection.Query<Battle>(sql,new {userId = userId}).ToList();
        }

        public void Save(Battle newBattle)
        {
            var sql = @"Insert into Battle(OpponentName, ShotsFired, Hits, Misses, Gun, Score, UserId)
                  Values(@OpponentName, @ShotsFired, @Hits, @Misses, @Gun, @Score, @UserId)";

            _dbConnection.Execute(sql, newBattle);
        }


        
    }
}
