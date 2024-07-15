using EngineLineLibrary.Exceptions;

namespace EngineLineLibrary.Connection.Devices
{
    public class ElmObd2Device : IObd2Device
    {
        private readonly IConnection _connection;
        private readonly string protocol;

        private bool isInitialized = false;
        private bool isCurrentlyInitializing = false;

        // NOTE:
        // The Protocol name is what is expected here not an AT command
        // Use a dictionary to map the name to an AT command.
        // This way the client doesn't need to worry about the specific command to pass in.
        // Depending on the device being used it will be converted to the appropriate command
        public ElmObd2Device(IConnection connection, string protocol)
        {
            _connection = connection;
            this.protocol = protocol;
        }

        public bool InitalizeDevice()
        {
            var init_commands = new List<string>() { "ATD", "ATE0", protocol, "0100" };

            isCurrentlyInitializing = true;

            init_commands.ForEach(command =>
            {
                Query(command);
            });

            isInitialized = true;

            return isInitialized;
        }

        public string Query(string command)
        {
            string response;

            if (isCurrentlyInitializing || isInitialized)
                response = _connection.SendMessage(command);
            else
                response = "UNINITIALIZED CONNECTION";

            var trimmedResponse = response.Trim(new char[] { '>', '\r', '\n' });
            CheckForErrorsInResponse(trimmedResponse);

            return trimmedResponse;
        }

        public void Disconnect()
        {
            _connection.Disconnect();
        }

        private static void CheckForErrorsInResponse(string response)
        {
            Dictionary<string, Exception> error_mapping = new Dictionary<string, Exception>()
            {
                { "?", new InvalidCommandReceivedException() },
                { "DATA ERROR", new VehicleDataException("Data from vehicle was invalid or could not be recovered") },
                { "NO DATA", new VehicleDataException("No data was received from the vehicle") },
                { "BUS BUSY", new VehicleConnectionException("To much activity on the bus to send a message") },
                { "BUS ERROR", new VehicleConnectionException("A generic problem has occurred") },
                { "CAN ERROR", new VehicleConnectionException("The CAN system had difficulty initializing, sending, or receiving") },
                { "UNABLE TO CONNECT", new VehicleConnectionException("Connection with the vehicle could not be established") },
                { "SEARCHING...\r\nUNABLE TO CONNECT", new VehicleConnectionException("Connection with the vehicle could not be established") },
                { "STOPPED", new VehicleConnectionException("The OBD operation has be interrupted") },
                { "UNINITIALIZED CONNECTION", new VehicleConnectionException("The OBD2 Device has not been initialized") }
            };

            if (error_mapping.ContainsKey(response))
            {
                throw error_mapping[response];
            }
        }
    }
}
