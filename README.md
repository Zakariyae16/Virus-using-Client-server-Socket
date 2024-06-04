This client-server virus application is designed to illustrate the concepts of data collection, screenshot capture, live video streaming, and cookie management. It is divided into two main components: a client application and a server application. The client collects data and sends it to the server via sockets. The server receives the data, displays it through a graphical interface, streams the video live, and stores the data in a database using ADO.NET.

2. Application Architecture
2.1. Client Application
The client application is responsible for:

Collecting user data (system information, files, etc.).
Periodically capturing screenshots.
Streaming live video of the user's desktop.
Collecting cookies from web browsers.
Sending all this information to the server via sockets.
Key Features:
Data Collection: Using C# classes to retrieve system information, user details, and browser data.
Screenshot Capture: Using Bitmap and Graphics to capture the screen at regular intervals.
Video Streaming: Compressing and sending the captured images in real-time.
Cookie Collection: Using automation to access cookies stored by browsers.
Socket Communication: Using the TcpClient class to send data to the server.
2.2. Server Application
The server application is responsible for:

Receiving data sent by the client.
Displaying screenshots and live video through a graphical interface.
Storing the received data in a database using ADO.NET.
Key Features:
Data Reception: Using the TcpListener class to listen for and accept client connections.
Graphical Interface: Using Windows Forms or WPF to display screenshots and live video.
Data Storage: Using ADO.NET to insert data into a SQL Server or other database.
