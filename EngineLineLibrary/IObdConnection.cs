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
        // Mode 01
        public int ReadRpm();
        public int ReadSpeed();
        public int ReadTemperature();
        public decimal ReadTPS();
        public decimal ReadMAF();
        public decimal ShortTermFuelTrimB1();
        public decimal ShortTermFuelTrimB2();
        public decimal LongTermFuelTrimB1();
        public decimal LongTermFuelTrimB2();
        // Mode 03
        public List<string> ReadEngineCodes();
        public bool ResetCodes();
        public void WriteToSerialAndWaitForResponse(string command, CommandType commandType);
        public void CloseConnection();
    }
}
