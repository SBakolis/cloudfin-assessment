using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServerLoader
{
    public sealed class DataLoader
    {
        private static List<Trader> traders = new List<Trader>()
        {
            new Trader
            {
                Code = "sql1",
                Street = "sqlAdd1",
                Description = "sSupp1"
            },
            new Trader
            {
                Code = "sql2",
                Street = "sqlAdd2",
                Description = "sqlSupp2"
            }
        };

        private readonly string server;
        private readonly string userId;
        private readonly string password;

        public DataLoader(string server, string userId, string password)
        {
            this.server = server;
            this.userId = userId;
            this.password = password;
        }

        public Task<Trader> LoadTrader(string code)
        {
            CheckConnection();

            var trader = traders.FirstOrDefault(t => t.Code == code);
            if (trader == null) throw new Exception("Trader not found");

            return Task.FromResult(trader);
        }

        public Task<List<Trader>> LoadTraders()
        {
            CheckConnection();

            return Task.FromResult(traders);
        }

        public Task InsertTrader(Trader trader)
        {
            CheckConnection();

            if (string.IsNullOrWhiteSpace(trader.Code) || string.IsNullOrWhiteSpace(trader.Description)) throw new Exception("Code and description are required");

            var dbTrader = traders.FirstOrDefault(s => s.Code == trader.Code);
            if (dbTrader != null) throw new Exception("Trader already exists");

            traders.Add(trader);

            return Task.CompletedTask;
        }

        public Task UpdateTrader(Trader trader)
        {
            CheckConnection();

            var dbTrader = traders.FirstOrDefault(s => s.Code == trader.Code);
            if (dbTrader == null) throw new Exception("Trader not found");

            dbTrader.Description = trader.Description;
            dbTrader.Street = trader.Street;

            return Task.CompletedTask;
        }

        public Task DeleteTrader(string id)
        {
            CheckConnection();

            var trader = traders.FirstOrDefault(s => s.Code == id);
            if (trader == null) throw new Exception("Trader not found");

            traders.Remove(trader);

            return Task.CompletedTask;
        }

        private void CheckConnection()
        {
            if (server.ToLower() != "server" || userId.ToLower() != "userid" || password != "password") throw new ArgumentException("Wrong connection info");
        }
    }
}
