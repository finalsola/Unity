using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using UnityEngine.UI;
public class Sorkect : MonoBehaviour
{
    Socket clientSocket;
    int co=0;
    byte[] buffer = new byte[1024 * 1024];
    string ip = "10.20.70.55";
    int port = 8888;
    string getMessage, sendMessage;
    public InputField inputF;
    bool canSend;
    // Use this for initialization
    void Start()
    {

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//实例化一个socket
        IPAddress ipAddress = IPAddress.Parse(ip);//生成IP地址
        clientSocket.Connect(ipAddress, port);//根据IP地址和端口号，使socket指向（连接）服务器
        Thread reciveThread = new Thread(Receive);//开一个线程，用于接收消息。因为Receive函数在没有消息时没，会阻塞
        reciveThread.Start();
    }

    //该方法等待接收
    void Receive()
    {
        while (true)
        {
            int bufCount = clientSocket.Receive(buffer);//接收到的消息存储到buffer中，并将其字节数存到bufCount中
            string message = Encoding.UTF8.GetString(buffer, 0, bufCount);//byte[]转string
            getMessage = message;
        }
    }
    private void OnGUI()
    {
        GUILayout.Label(getMessage);
    }
    //根据输入框内容发送消息给服务器
    public void ChangeMessage()
    {
            sendMessage = inputF.text;
            byte[] buffer = Encoding.UTF8.GetBytes(sendMessage);
            clientSocket.Send(buffer);
    }
}
