using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SimulationDeviceMQTT
{
    public class Publisher
    {
        public static int varclass = 0;
        private MqttClient sender;

        public Publisher()
        {
     
        }
        public  Publisher(int tenta)
        {
            MqttClient client = new MqttClient("test.mosquitto.org");
;
            client.Connect(Guid.NewGuid().ToString());
            client.Publish("hello" , Encoding.UTF8.GetBytes("Hello, I'm a new re" + tenta),MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,true);
            
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

