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

namespace Terminal_Publisher
{
    public partial class Form_Publisher : Form
    {
        MqttClient client;

        public Form_Publisher()
        {
            InitializeComponent();

            // create client instance
            client = new MqttClient(IPAddress.Parse("127.0.0.1"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
        }

        private void button_green_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("ON");

            string strValue = "green";

            // publish a message on "/home/temperature" topic with QoS 2
            client.Publish("/terminal", Encoding.UTF8.GetBytes(strValue)  
                /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("OFF");

            string strValue = "red";

            // publish a message on "/home/temperature" topic with QoS 2
            client.Publish("/terminal", Encoding.UTF8.GetBytes(strValue)  
                /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
        }

        private void Form_Publisher_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
