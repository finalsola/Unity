using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using UnityEngine;

public class ServerTest : MonoBehaviour {

    Socket serverSocket; //创建一个服务器的socket套接字

    string ip = "127.0.0.1";
    int port = 5555;

	// Use this for initialization
	void Start () {

        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //同客户端的设置

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port); //通过IP地址和端口组合成一个结构，IPEndPoint结构

        serverSocket.Bind(endPoint); //绑定IP地址和端口，用来接收对应端口的消息请求。
        serverSocket.Listen(10); //设置监听

        Thread acceptThread = new Thread(Accept);
        acceptThread.Start();

	}

    void Accept()
    {
        Debug.Log("服务器已经开启，等待客户端链接");
        while (true)
        {
            Socket clientSocket = serverSocket.Accept(); //监听其他源主机的访问请求，如果有其他源主机请求数据发过来的时候，就从阻塞形态放开，返回值就是连接进来的客户端的socket。
            if (clientSocket != null)
            {
                Debug.Log("有一个客户端链接成功!");
                string message = "连接成功!";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(buffer); //客户端socket发送数据给他。
            }
        }
    }
}
