// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TransportTCP : MonoBehaviour
{
    Socket m_listener;
    bool m_isServer;
    Socket m_socket;
    bool m_isConnected;
   public bool StartServer(int port, int connectionNum)
    {
        // 리스닝 소켓 생성
        m_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_listener.Bind(new IPEndPoint(IPAddress.Any, port));
        m_listener.Listen(connectionNum);
        m_isServer = true;

        return true;
    }

    public void StopServer()
    {
        // 리스닝 소켓 닫기
        m_listener.Close();
        m_listener = null;
        m_isServer = false;
    }

    public bool Connect(string address, int port)
    {
       
        // 소켓 연결

        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_socket.NoDelay = true;
        m_socket.Connect(address, port);
        m_socket.SendBufferSize = 0;
        m_isConnected = true;

        return true;
    }

    public bool Disconnect()
    {
        // 소켓을 닫는다.
        m_socket.Shutdown(SocketShutdown.Both);
        m_socket.Close();
        m_socket = null;

        m_isConnected = false;


        return true;
    }

    private PacketQueue m_sendQueue = new PacketQueue(); // 송신 버퍼
    private PacketQueue m_recvQueue = new PacketQueue(); // 수신 버퍼

    public int Send(byte[] data, int size)
    {
        return m_sendQueue.Enqueue(data, size);
    }

    public int Receive(ref byte[] buffer, int size)
    {
        return m_recvQueue.Dequeue(ref buffer, size);
    }

    
    
}
