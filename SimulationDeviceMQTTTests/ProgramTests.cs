using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationDeviceMQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDeviceMQTT.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        SimulationDeviceMQTT.Program program = new SimulationDeviceMQTT.Program();
        private int _ten;

        [TestMethod()]
        public void MainTest()
        {
            //SimulationDeviceMQTT.Program.CreateDevice(10);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateDeviceTest()
        {
            SimulationDeviceMQTT.Program.CreateDevice(10);

            _ten = SimulationDeviceMQTT.Program.tentative;

            Assert.AreEqual(10,_ten);
        }
    }
}