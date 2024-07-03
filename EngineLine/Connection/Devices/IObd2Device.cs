using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLine.Connection.Devices
{
    public interface IObd2Device
    {
        public void InitalizeDevice(string protocol);
        public string Query(string command);
        public void Disconnect();
    }
}
