using EngineLine.Exceptions;

namespace EngineLine.Connection.Devices
{
    public class ElmObd2Device : IObd2Device
    {
        private readonly IConnection _connection;

        public ElmObd2Device(IConnection connection) 
        {
            _connection = connection;
        }

        public void InitalizeDevice(string protocol)
        {
            var init_commands = new List<string>() { "ATD", "ATE0", "ATS0", protocol, "0100" };

            init_commands.ForEach(command =>
            {
                Query(command);
            });
        }

        public string Query(string command)
        {
            var response = _connection.SendMessage(command);

            CheckForErrorsInResponse(response);

            return response;
        }

        public void Disconnect()
        {
            _connection.Disconnect();
        }

        private static void CheckForErrorsInResponse(string response)
        {
            var trimmedResponse = response.ToString().Trim(new char[] { '>', '\r', '\n' });

            switch (trimmedResponse)
            {
                case "?":
                    throw new InvalidCommandReceivedException();
                case "DATA ERROR":
                    throw new VehicleDataException("Data from vehicle was invalid or could not be recovered");
                case "NO DATA":
                    throw new VehicleDataException("No data was received from the vehicle");
                case "BUS BUSY":
                    throw new VehicleConnectionException("To much activity on the bus to send a message");
                case "BUS ERROR":
                    throw new VehicleConnectionException("A generic problem has occurred");
                case "CAN ERROR":
                    throw new VehicleConnectionException("The CAN system had difficulty initializing, sending, or receiving");
                case "UNABLE TO CONNECT":
                    throw new VehicleConnectionException("Connection with the vehicle could not be established");
                case "SEARCHING...\r\nUNABLE TO CONNECT":
                    throw new VehicleConnectionException("Connection with the vehicle could not be established");
                case "STOPPED":
                    throw new VehicleConnectionException("The OBD operation has be interrupted");
                default:
                    break;
            }
        }
    }
}
