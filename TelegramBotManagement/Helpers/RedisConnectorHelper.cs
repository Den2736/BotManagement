using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Helpers
{
    public static class RedisConnectorHelper
    {
        private static Lazy<ConnectionMultiplexer> LazyConnection => new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("localhost");
        });

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static bool ConnectionIsWell()
        {
            return Connection.IsConnected;
        }
    }
}
