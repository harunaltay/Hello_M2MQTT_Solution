using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Hello_Subscribe_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba Subscriber - MQTT");

            MqttClient client = new MqttClient(IPAddress.Parse("127.0.0.1"));

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe
                (new string[] { "/hello" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // access data bytes throug e.Message
            byte[] buffer = e.Message;
            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            Console.WriteLine(s);
        }
    }
}
