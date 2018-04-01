using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Hello_Publish_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba MQTT");

            // create client instance
            MqttClient client = new MqttClient(IPAddress.Parse("127.0.0.1"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //string strValue = Convert.ToString(value);
            string strValue = "Merhaba_VS_M2MQTT";

            // publish a message on "/home/temperature" topic with QoS 2
            client.Publish("/hello", Encoding.UTF8.GetBytes(strValue)  /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );

        }
    }
}
