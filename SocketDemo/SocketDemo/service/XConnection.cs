using System;
using System.IO;
using System.Net.Sockets;
using Framework.Protocol;
using SocketDemo;
namespace Framework.Service
{

    public class XConnection
    {
        public XConnection()
        {
        }

        public virtual bool IsAsync() { return false; }        
        public virtual void Process(Command cmd, object packet) { }

        public void Parse(object packet)
        {
            Process((Command)1, packet);
        }                  

    }
}
