using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReinforcementCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementCalc.Tests
{
    [TestClass()]
    public class BeamTests
    {
        [TestMethod()]
        public void CalculateReinforcementTest()
        {
            Beam beam = new Beam(400, 700, 654, 30, 500, 30, 8, 25);

            beam.CalculateReinforcement();

            Assert.AreEqual(25.748, Math.Round(beam.RequiredReinforcement,3));
        }
    }
}