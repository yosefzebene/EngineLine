using System.Collections;

namespace EngineLine.Utility
{
    public static class ResponseHelper
    {
        public static string[] SingleLineResponseToHexArray(string response)
        {
            return response.Split(' ');
        }

        public static string[][] MultiLineResponseToHexArray(string response)
        {
            var returnValue = new List<string[]>();

            var lines = response.Split("\r\n");
            foreach (var line in lines)
            {
               returnValue.Add(SingleLineResponseToHexArray(line));
            }

            return returnValue.ToArray();
        }

        public static bool[] HexToBoolArray(string[] hexValues)
        {
            var boolList = new List<bool>();

            foreach (var hex in hexValues)
            {
                var bitArray = new BitArray(new[] { Convert.ToByte(hex, 16) });

                for (int i = bitArray.Length - 1; i >= 0; i--)
                {
                    boolList.Add(bitArray[i]);
                }
            }

            return boolList.ToArray();
        }
    }
}
