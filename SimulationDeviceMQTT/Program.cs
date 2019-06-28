using System;
using System.Threading.Tasks;

namespace SimulationDeviceMQTT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int nomberdevices = 10;
            CreateDevice(nomberdevices);
        }
        public static void CreateDevice(int number)
        {
            Device[] devices = new Device[number];

            Parallel.For(0, number, (i, state) =>
            {
                devices[i] = new SimulationDevice();
                Data data = devices[i].FactoryMethod();
                Console.WriteLine("Device created {0}", data.GetType().Name);
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

    public class SimulationDevice : Device
    {
        public override Data FactoryMethod()
        {
            return new SendData();
        }
    }
}

