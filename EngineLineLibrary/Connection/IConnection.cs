using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLineLibrary.Connection
{
    public interface IConnection
    {
        public bool Connect(string port, int baudRate);
        public bool Disconnect();
        public string SendMessage(string message);
    }
}
