using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class ClientSocketTest : MonoBehaviour {

    public Text outText;

    Socket clientSocket;//创建一个客户端socket，通过这个socket就可以和服务器通讯

    byte[] buffer = new byte[1024 * 1024]; //缓存字节数组，是用来接收服务器发回来的字节流

    string ip = "127.0.0.1"; //此socket将要连接的目标主机的ip地址
    int port = 5555; //此socket将要连接的目标主机的端口号

	// Use this for initialization
	void Start () {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //通过socket的构造函数设定socket类型和设置：协议族，传输方式，使用的通讯协议，
        IPAddress ipAddress = IPAddress.Parse(ip);
        clientSocket.Connect(ipAddress, port); //对对应的地址和端口号进行连接

        Thread reciveThread = new Thread(Recive); //新启动一个辅助线程，专门用来接收服务器返回给客户端的消息。
        reciveThread.Start(); //线程通过构造函数创建好之后使用Start启动此线程。
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Recive()
    {
        while (true)
        {
            if (clientSocket == null) //如果发现客户端(本地的)的socket为null，就跳出循环，结束线程。
                break;
			int bufCount = clientSocket.Receive(buffer); //使用recive方法接收服务器发回来的消息，传入一个buffer缓存数组，返回真实接收到的字节数
			string message = Encoding.UTF8.GetString(buffer,0, bufCount);
            outText.text = message;
        }
    }
}
