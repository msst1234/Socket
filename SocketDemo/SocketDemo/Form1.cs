using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Framework.Service;
namespace SocketDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            timer.Tick += new System.EventHandler(this.sendTimer);
             timer.Interval = 2000;

            UIController.Instance.SubscribeRouteChangedMsg(AddText);

            netHelper = new SocketHelper("127.0.0.1", 2112);
            XConnection concreator = new PushMsgConnection();
            netHelper.SetConnection(concreator);
            netHelper.AsyncReceive();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (timer.Enabled)
            {
                timer.Stop();
              
            }
            else
            {
                timer.Start();
             
            }
        }


        private void sendTimer(object sender, EventArgs e)
        {

            AddText("开始发送："+DateTime.Now.ToString("hh:mm:ss  fff"));

            string sendingMessage = "Hello World Socket Test111111";
            byte[] forwardMessage = Encoding.ASCII.GetBytes(sendingMessage + "[FINAL]");
            netHelper.AsyncSend(forwardMessage);

        }


        public void AddText(object text)
        {
            this.Invoke(new EventHandler(delegate
            {
                richTextBox1.Text = richTextBox1.Text + "\r\n" + text.ToString();
            }));
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        SocketHelper netHelper = null;

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
