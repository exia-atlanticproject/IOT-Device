using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDeviceMQTT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int nomberdevices = 100;
            CreateDevice(nomberdevices);
        }
        public static void CreateDevice(int number)
        {
            Device[] devices = new Device[number];
            for (int i = 0; i < number; i++)
            {
                devices[i] = new SimulationDevice();
            }
            Parallel.For(0, number, (i, state) =>
            {
                devices[i] = new SimulationDevice();
                Publisher publisher = new Publisher();
            });
        }
    }

        public abstract class Data

        {
        }

        public class SendData : Data

        {
            Publisher publisher = new Publisher();

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

