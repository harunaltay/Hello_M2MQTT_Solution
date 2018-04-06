// Source:
// https://anilkumarlive.wordpress.com/web-api-abnd-consume-in-winforms/
// I guess, the same: http://www.dotnetfunda.com/articles/show/2341/crud-operation-using-web-api-and-windows-application

using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace Terminal_Publisher
{
    public partial class Terminal
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string datetime { get; set; }
        public string topic { get; set; }
    }

    public partial class Form_Publisher : Form
    {
        public static string message_mqtt = "un initialized";
        public static string topic_mqtt = "/terminal";

        MqttClient client;

        ////static HttpClient client_web_api = new HttpClient();
        //HttpClient client_web_api = new HttpClient();

        ////static async Task<Uri> CreateTerminalAsync(Terminal terminal)
        //async Task<Uri> CreateTerminalAsync(Terminal terminal)
        //{
        //    HttpResponseMessage response = await client_web_api.PostAsJsonAsync(
        //        "api/terminals", terminal);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

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
            message_mqtt = "green";

            client.Publish(topic_mqtt, Encoding.UTF8.GetBytes(message_mqtt)  
                /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );

            //RunAsync().GetAwaiter().GetResult();

            AddProduct();
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            message_mqtt = "red";

            client.Publish(topic_mqtt, Encoding.UTF8.GetBytes(message_mqtt)  
                /*, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE */ );

            // RunAsync().GetAwaiter().GetResult();

            AddProduct();
        }

        private void Form_Publisher_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }

        private async void AddProduct()
        {
            Terminal t = new Terminal();
            t.message = message_mqtt;
            t.datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            t.topic = topic_mqtt;

            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(t);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                //var result = await client.PostAsync("http://localhost:58895/", content);
                var result = await client.PostAsync("http://localhost:58895/api/terminals", content);
            }
        }

        ////static async Task RunAsync()
        //async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client_web_api.BaseAddress = new Uri("http://localhost:58895/");
        //    client_web_api.DefaultRequestHeaders.Accept.Clear();
        //    client_web_api.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        // Create a new product
        //        Terminal terminal = new Terminal
        //        {
        //            //Id = 100,
        //            message = "Mesaj from Terminal_Publisher", // message_mqtt,
        //            datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"),
        //            topic = "/terminal" // topic_mqtt
        //        };

        //        var url = await CreateTerminalAsync(terminal);
        //        //Console.WriteLine($"Created at {url}");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    //Console.ReadLine();
        //}

    }
}
