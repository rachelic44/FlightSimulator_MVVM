using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class AutoPilotModel : BaseNotify
    {
     
        private Queue<string> commandsQueue;

        public AutoPilotModel()
        {
            this.commandsQueue = new Queue<string>();
        }



        public void writeMessages(string messages)
        {
           
            if (messages != "")
            {
                Console.WriteLine("sending it");
                string[] result = messages.Split('\n');

                /* push all the messages to the queue */
                foreach (string line in result)
                {
                    if (line == "\r\n" || line == "\r" || line == "\n") { continue; };
                    this.commandsQueue.Enqueue(line);
                }

                /* create a task to run in background and send each meassage, 2 seconds between each one. */
                Task t = new Task(() => {
                    Console.WriteLine("g first1 1 1 ");
                    while (commandsQueue.Count > 0)
                    {
                        Connection.Instance.TelnetClient.write(commandsQueue.Peek() + "\r\n");
                        commandsQueue.Dequeue();
                        Thread.Sleep(2000);
                    }
                });
                t.Start();
            }        
        }

    }
}
