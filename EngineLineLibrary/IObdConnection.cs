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
        public Response Query(Request request);
        public void CloseConnection();
    }
}
