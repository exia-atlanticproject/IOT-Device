using System;
using System.Diagnostics;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SimulationDevice
{
    public class Publisher
    {
        public Publisher()
        {
            ConnectedClient();
        }
        public int RandomNumber(int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void ConnectedClient()
        {
            MqttClient client = new MqttClient("10.154.128.153");
            client.Connect(Guid.NewGuid().ToString());
            RandomNumber(-20, 40);
            client.Publish("calculation", Encoding.UTF8.GetBytes("temps:" + RandomNumber(-20, 40)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            client.MqttMsgPublished += client_MqttMsgPublished;
  
        }
        public void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            MqttClient client = (MqttClient)sender;
            Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            if (e.IsPublished)
            {
                client.Disconnect();
                Console.WriteLine("Connection Closed");
             
            }
        }
    }
}