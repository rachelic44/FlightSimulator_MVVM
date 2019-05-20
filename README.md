# FlightSimulator_MVVM

This project represents the flight gear project with MVVM implementation in C#.
When running the project and pressing the "Connect" button, a server side is opened, to read data from the simulator.
Aside to the server, a client connection is being opened too, in order to reach the simulator as a client and send tasks,
such as requesting the simulator to change the aileron state, the rudder and centra. 
Requests can be send from the manual command (moving the joystick control) or from the automatic control (using the window).
MVVM is implemented for each entity: Joystick, automatic, FlightBoard and centra.
The programm tracks the plain route by using the server listening with event, and draws the route on the flight board map.

Enjoy
