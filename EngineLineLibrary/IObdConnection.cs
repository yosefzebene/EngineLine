namespace EngineLineLibrary
{
    public interface IObdConnection
    {
        public Response Query(Request request);
        public void CloseConnection();
    }
}
