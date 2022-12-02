using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
