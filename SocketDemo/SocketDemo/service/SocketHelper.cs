using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Framework.Service;
using System.Text;
namespace SocketDemo
{
    public  class SocketHelper
    {

        public SocketHelper(string ip, int port)
        {
            IPAddress address = IPAddress.Parse(ip);
            m_IPEndPoint = new IPEndPoint(address, port);
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_Socket.Connect(m_IPEndPoint);
        }



        public void SetConnection(XConnection connection)
        {
            m_Connection = connection;
        }
        public bool IsConnection()
        {
            return m_Socket.Connected;
        }

        public bool Send(byte[] Array)
        {
            bool ret = false;
            try
            {

                if (!m_Socket.Connected)
                {
                    Connection();
                }
                m_Socket.Send(Array);
                ret = true;
            }
            catch (Exception ex)
            {
                //日志
            }
            return ret;
        }

        public  void AsyncSend( byte[] Array)
        {
            if (!m_Socket.Connected)
            {
                Connection();
            }
            m_Socket.BeginSend(Array, 0, Array.Length, 0, new AsyncCallback(SendCallback), m_Socket);

        }
        public  void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }

        public byte[] Receive(ref int length)
        {
            byte[] ret = new byte[MaxLen];
            try
            {

                if (m_Socket.Connected)
                {
                    length= m_Socket.Receive(ret);
                }
            }
            catch (Exception ex)
            {
                //日志
            }
            return ret;
        }




        public void AsyncReceive()
        {
          
            m_Socket.BeginReceive(Buffer, 0, BufferSize, 0, new AsyncCallback(ReceiveCallback), this);
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                SocketHelper session = (SocketHelper)ar.AsyncState;
                int bytesread = m_Socket.EndReceive(ar);
                if (0 < bytesread)
                {
                    //取最后四个字节判断是否为包尾，如果是则说明已经收到一个完整的数据包了
                    if (session.IsIntegrity())
                    {
                       
                        m_Connection.Parse(Encoding.ASCII.GetString(Buffer, 0, bytesread));
                        this.AsyncReceive();
                    }
                    else
                    {
                        m_Socket.BeginReceive(Buffer, 0, BufferSize, 0, new AsyncCallback(ReceiveCallback), session);
                    }
                }
                else
                {
                    if (session.IsIntegrity())
                    {
                        this.AsyncReceive();
                        m_Connection.Parse(Buffer);
                        session = null;
                    }
                    else
                    {
                        this.Close();
                      
                    }
                }
            }
            catch (Exception e)
            {
                //出现异常，关闭连接
                this.Close();
               
            }
        }


        public void Close()
        {
            try
            {
                //关闭socket  
                m_Socket.Shutdown(SocketShutdown.Both);
                m_Socket.Disconnect(true);
                m_Socket.Close();
            }
            catch (Exception ex)
            {
                //日志
            }
        }


        public void Connection()
        {
            try
            {
                if (!m_Socket.Connected)
                {
                    Close();
                    m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    m_Socket.Connect(m_IPEndPoint);
                }

            }
            catch (Exception ex)
            {
                //日志
            }
        }
        bool IsIntegrity()
        {
            //TODO:返回是否有包尾
            return true;
        }


        Socket m_Socket = null;
        static readonly int MaxLen = 50000;
        IPEndPoint m_IPEndPoint = null;
        static int  BufferSize = 128;
        byte[] Buffer = new byte[BufferSize];
        MemoryStream Data = new MemoryStream();
        XConnection m_Connection = null;
    }
}
