using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace Hello_Publish_WinFormsApp
{
    public partial class Terminal
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string datetime { get; set; }
        public string topic { get; set; }
    }

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
            // client.Publish("/hello", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );
            client.Publish("/hello", Encoding.UTF8.GetBytes("Hello from Publish"));
        }

        private void Form_Publish_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }
    }
}
