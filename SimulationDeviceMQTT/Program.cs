using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDeviceMQTT
{

    class Program
    {
        public static int tentative = 0;


        static void Main(string[] args)
        {
            int nomberdevices = 500;
            Device[] devices = new Device[nomberdevices];

            for (int i = 0; i < nomberdevices; i++)
            {
                 devices[i] = new SimulationDevice();
            }

            foreach (Device device in devices)
            {
                tentative = tentative + 1;
                Data data = device.FactoryMethod();
                Console.WriteLine("Device created {0}", data.GetType().Name);
            }
        }

      

        abstract class Data

        {
        }

        class SendData : Data

        {
            Publisher publisher = new Publisher(tentative);
        }

        abstract class Device

        {
            public abstract Data FactoryMethod();
        }

        class SimulationDevice: Device
        {
            public override Data FactoryMethod()
            {
                return new SendData();
            }
        }
    }
}
