using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLine.Exceptions
{
    [Serializable]
    public class VehicleDataException : Exception
    {
        private const string DefaultMessage = "There was a problem with the data received from the vehicle";

        public VehicleDataException() : base(DefaultMessage) { }

        public VehicleDataException(string message) : base(message) { }
        
        public VehicleDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}
