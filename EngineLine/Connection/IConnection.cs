using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLine.Connection
{
    public interface IConnection
    {
        public bool Connect(string port, int baudRate);
        public void Disconnect();
        public bool GetConnectionStatus();
        public string SendMessage(string message);
    }
}
