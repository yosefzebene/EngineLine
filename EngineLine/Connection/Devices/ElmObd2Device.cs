namespace EngineLine.Connection.Devices
{
    public class ElmObd2Device : IObd2Device
    {
        private readonly IConnection _connection;

        public ElmObd2Device(IConnection connection) 
        {
            _connection = connection;
        }

        public bool InitalizeDevice(string protocol)
        {
            var init_commands = new List<string>() { "ATD", "ATE0", protocol, "0100" };

            try
            {
                init_commands.ForEach(command =>
                {
                    Query(command);
                });
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string Query(string command)
        {
            var response = _connection.SendMessage(command);

            // NOTE: Add error checking

            return response;
        }
    }
}
