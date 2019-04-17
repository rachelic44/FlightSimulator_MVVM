using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;


namespace FlightSimulator.Model
{
    public interface ISimulatorModel 
    {
        void connectAsClient(string ip, int port);
        void disconnectAsClient();
        void startClient();

        void openServer();

        void startServer();

        void stopServer();
    
    }
}
