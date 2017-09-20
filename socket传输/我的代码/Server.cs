using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
public class Server : MonoBehaviour {
    Socket serverSocket;
    byte[] buffer = new byte[1024 * 1024];
	string ip = "127.0.0.1";
	int port = 5555;
    private void Start()
    {
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//声明一个socket，该socket监听访问服务器的客户端
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);


        serverSocket.Bind(endPoint);//socket绑定IP和端口
        serverSocket.Listen(10);//设置最大监听数量

        Thread acceptThread = new Thread(Accept);
        acceptThread.Start();
    }
    void Accept()
    {
        Socket clientSocket;

        while (true)
        {
            clientSocket = serverSocket.Accept();//不断地持续等待客户端的访问
            if (clientSocket != null)
            {
				break;
				Debug.Log("有客户端连接");
            }
        }
        while(true)
        {
			int bufcount = clientSocket.Receive(buffer);//由于Accept也会阻塞，如果想要实现多客户端连接，需要把Accept和Receive写在两个线程里面
			string message = Encoding.UTF8.GetString(buffer, 0, bufcount) + "发回给你";
			buffer = Encoding.UTF8.GetBytes(message);
			clientSocket.Send(buffer);
        }  
    }
}
