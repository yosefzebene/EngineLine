using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EngineLineLibrary.ObdConnection;

namespace EngineLineLibrary
{
    public interface IObdConnection
    {
        public int ReadRpm();
        public int ReadSpeed();
        public int ReadTempreture();
        public decimal ReadTPS();
        public decimal ReadMAF();
        public List<string> ReadEngineCodes();
        public bool ResetCodes();
        public void WriteToSerialAndWaitForResponse(string command, CommandType commandType);
        public void CloseConnection();
    }
}
