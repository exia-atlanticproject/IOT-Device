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
    class Publisher
    {
        public static int varclass = 0;

        public Publisher()
        {
     
        }


        public  Publisher(int tenta)
        {
            MqttClient client = new MqttClient("10.154.128.153");
            client.Connect(Guid.NewGuid().ToString());
            client.Publish("hello" , Encoding.UTF8.GetBytes("Hello, I'm a new re" + tenta),MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,true);

            client.MqttMsgPublished += client_MqttMsgPublished;
            //Thread.Sleep(TimeSpan.FromMilliseconds(10));
            Console.WriteLine(tenta);





        }




        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            MqttClient client = (MqttClient)sender;

            Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            if (e.IsPublished)
            {
                client.Disconnect();
                Console.WriteLine("Connection Closed");

            }


        }

        static async void Publish(){
            
        }
         

    }
}

