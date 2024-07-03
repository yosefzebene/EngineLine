using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLine.Exceptions
{
    [Serializable]
    public class InvalidCommandReceivedException : Exception
    {
        private const string DefaultMessage = "The command is not valid";

        public InvalidCommandReceivedException() : base(DefaultMessage) { }

        public InvalidCommandReceivedException(string message) : base(message) { }

        public InvalidCommandReceivedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
