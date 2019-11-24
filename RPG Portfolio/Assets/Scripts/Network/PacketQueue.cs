// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;



public class PacketQueue 
{
    struct PacketInfo // 패킷 저장 정보
    {
        public int offset;
        public int size;

    };
    

    private MemoryStream m_streamBuffer; // 데이터를 보존할 버퍼

    private List<PacketInfo> m_offsetList; // 패킷 정보 관리 리스트

    private int m_offset = 0;// 메모리 배치 오프셋

    private Object lockObj = new Object(); // 락 오브젝트

    public PacketQueue() // 생성자 (여기서 초기화시킴)
    {
        m_streamBuffer = new MemoryStream();
        m_offsetList = new List<PacketInfo>();
    }
    
    public int Enqueue(byte[] data, int size) // 큐에 데이터 추가
    {
        PacketInfo info = new PacketInfo();

        // 패킷 정보 작성
        info.offset = m_offset;
        info.size = size;

        lock(lockObj)
        {
            m_offsetList.Add(info); // 패킷 저장 정보 보존

            m_streamBuffer.Position = m_offset; // 패킷 데이터 보존
            m_streamBuffer.Write(data, 0, size);
            m_streamBuffer.Flush();
            m_offset += size;
        }

        return size;
    }

    public int Dequeue(ref byte[] buffer, int size) // 큐에서 데이터 리턴
    {
        if(m_offsetList.Count <= 0)
        {
            return -1;

        }

        int recvSize = 0;

        lock(lockObj)
        {
            PacketInfo info = m_offsetList[0]; // 버퍼에서 해당하는 패킷 데이터를 가져 온다.
            int dataSize = Math.Min(size, info.size);
            m_streamBuffer.Position = info.offset;
            recvSize = m_streamBuffer.Read(buffer, 0, dataSize);

            if(recvSize > 0)// 큐 데이터를 앞으로 꺼냈으므로 맨 앞 데이터는 삭제
            {
                m_offsetList.RemoveAt(0);

            }

            //모든 큐 데이터를 꺼냈을 때는 스트림을 정리해서 메모리를 절약한다.
            if(m_offsetList.Count ==0)
            {
                Clear();
                m_offset = 0;
            }

        }
        return recvSize;
    }

    public void Clear()
    {
        byte[] buffer = m_streamBuffer.GetBuffer();
        Array.Clear(buffer, 0, buffer.Length);

        m_streamBuffer.Position = 0;
        m_streamBuffer.SetLength(0);
    }
}
