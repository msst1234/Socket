using System;
using System.IO;
using System.Net.Sockets;
using Framework.Service;
using Framework.Protocol;

namespace SocketDemo
{
    class PushMsgConnection:XConnection
    {
        public PushMsgConnection( )
            : base()
        {
        }

        public override bool IsAsync()
        {
            return true;
        }

        public override void Process(Command cmd, object packet)
        {
            try
            {
                XRequest request = null;
                switch (cmd)
                {
                  
                    case Command.UpdateVideoRecordState:
                        {
                            //TODO
                            break;
                        }

                    default:
                        {
                            request = new SyncRouteRequest();
                            break;
                        }
                }
                if (null != request)
                {
                    request.Process(packet);
                }
            }
            catch (Exception e)
            {
               
            }
        }
    }
}
