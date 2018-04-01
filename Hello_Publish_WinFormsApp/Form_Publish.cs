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

namespace Hello_Publish_WinFormsApp
{
    public partial class Form_Publish : Form
    {
        MqttClient client;

        public Form_Publish()
        {
            InitializeComponent();

            // create client instance
            client = new MqttClient(IPAddress.Parse("127.0.0.1"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Merhaba WinForms!");

            //string strValue = Convert.ToString(value);
            string strValue = "Merhaba Publish WinForms M2MQTT";

            // publish a message on "/home/temperature" topic with QoS 2
            client.Publish("/hello", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
        }
    }
}
