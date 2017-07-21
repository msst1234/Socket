using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace SocketDemo
{
    
    class UIController
    {
        public delegate void PushMessage(object msg);
        public static UIController Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public void SubscribeRouteChangedMsg(PushMessage callback)
        {
            m_UIChanged += callback;
            if (null == m_Messager)
            {
                m_Messager = AsyncOperationManager.CreateOperation(null);
            }
        }



        public void UnSubscribeRouteChangedMsg(PushMessage callback)
        {
            m_UIChanged -= callback;
        }


        public void SyncReSet(object strroute)
        {
            try
            {
                if (null != strroute)
                {
                  m_Messager.Post(new SendOrPostCallback(m_UIChanged), strroute);
                }
            }
            catch (Exception e)
            {
                
            }
        }


        static UIController m_Instance = new UIController();
        PushMessage m_UIChanged;
        AsyncOperation m_Messager = null;
    }
}
