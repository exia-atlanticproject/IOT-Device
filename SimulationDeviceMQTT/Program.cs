using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDeviceMQTT
{

    public class Program
    {
        public static int tentative = 0;


        public static void Main()
        {
            int nomberdevices = 2;
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



        public abstract class Data

        {
        }

        public class SendData : Data

        {
            Publisher publisher = new Publisher(tentative);
        }

        public abstract class Device

        {
            public abstract Data FactoryMethod();
        }

        public class SimulationDevice: Device
        {
            public override Data FactoryMethod()
            {
                return new SendData();
            }
        }
    }
}
