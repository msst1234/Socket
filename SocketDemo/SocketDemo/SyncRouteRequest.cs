using System;
using System.IO;
using Framework.Service;
using Framework.Protocol;

namespace SocketDemo
{
    /// <summary>
    /// 处理来自状态服务的路由同步请求
    /// </summary>
    class SyncRouteRequest:XRequest
    {
        public SyncRouteRequest()
            : base()
        {
        }

        public override void Process(object packet)
        {
            try
            {
                   UIController.Instance.SyncReSet(packet);
            }
            catch (Exception e)
            {
               
            }
        }
    }
}
