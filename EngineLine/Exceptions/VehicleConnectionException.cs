using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLine.Exceptions
{
    [Serializable]
    public class VehicleConnectionException : Exception
    {
        private const string DefaultMessage = "There was a problem with the connection to the vehicle";

        public VehicleConnectionException() : base(DefaultMessage) { }

        public VehicleConnectionException(string message) : base(message) { }

        public VehicleConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
