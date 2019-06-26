using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationDeviceMQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SimulationDeviceMQTT.Tests
{
    [TestClass()]
    public class PublisherTests
    {
        SimulationDeviceMQTT.Program program = new SimulationDeviceMQTT.Program();
        SimulationDeviceMQTT.Publisher publisher = new SimulationDeviceMQTT.Publisher();

        [TestMethod()]
        public void PublisherTest()
        {
        }

        [TestMethod()]
        public void PublisherTest1()
        {
            int i;

            for (i = 0; i < 10; i++)
            {
                publisher.ConnectedClient(i);

            }
            Assert.AreEqual(10, i);

        }
        [TestMethod()]
        public void client_MqttMsgPublishedTest()
        {
        }

        [TestMethod()]
        public void RandomNumberTest()
        {
            int number=0;
            bool validation = false;
           number = publisher.RandomNumber(20, 30);
            if (number >=20 && number <= 30)
            {
                validation = true;
            }

            Assert.IsTrue(validation);
        }
    }
}