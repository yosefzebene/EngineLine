using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLineLibrary
{
    public class Response
    {
        public string ResponseString { get; private set; }

        public Response(string response) 
        {
            ResponseString = response;
        }

        public string[] singleLineResponseToHexArray()
        {
            return ResponseString.Trim(new char[] { '>', '\r', '\n' }).Split(' ');
        }
    }
}
