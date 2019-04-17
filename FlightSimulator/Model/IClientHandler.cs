using System.Net.Sockets;

namespace FlightSimulator.Model
{
    internal interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}