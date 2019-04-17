using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          /* Console.WriteLine("5\n\n");
            ITelnetClient tclient = new MyTelnetClient();
            ISimulatorModel sm = new SimulatorModel(tclient);
            sm.connectAsClient("127.0.0.1", 5402);
            sm.startClient();
            Console.WriteLine("5\n\n");*/
        
            InitializeComponent();

           


        }

    }
}
