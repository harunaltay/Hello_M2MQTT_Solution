using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Terminal_Subscriber
{
    public partial class Form_Subscriber : Form
    {
        MqttClient client;
        string topic = "/terminal";

        public Form_Subscriber()
        {
            InitializeComponent();

            client = new MqttClient(IPAddress.Parse("127.0.0.1"));

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe
                (new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            byte[] buffer = e.Message;
            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            DateTime dateTime = DateTime.Now;

            if (s.Contains("green"))
            {
                label1.BackColor = Color.Lime;
                label1.Text = "ON";
                textBox1.Text += "green \t- " + dateTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + "\t" + topic  + "\r\n"; 
                // + Environment.NewLine da olabilir
            }
            else if (s.Contains("red"))
            {
                label1.BackColor = Color.Red;
                label1.Text = "OFF";
                textBox1.Text += "red \t- " + dateTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + "\t" + topic + "\r\n";
                //textBox1.AppendText("red" + "\r\n");
            }

        }

        private void Form_Subscriber_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
