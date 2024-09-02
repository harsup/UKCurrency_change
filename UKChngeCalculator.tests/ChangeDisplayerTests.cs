using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKChangeCalculator;

namespace UKChngeCalculator.tests
{
    [TestClass]
    public class ChangeDisplayerTests
    {
        private IChangeDispalyer _changeDisplayer;

        [TestInitialize]
        public void Setup()
        {
            _changeDisplayer = new ChangeDisplayer();
        }
        
        [TestMethod]
        public void DisplayChange_ShouldReturnCorrectChange()
        {
            var changeBreakdown = new Dictionary<string, int>
            {
                {"£10", 1},
                {"20p", 2 },
                {"2p", 1 }
            };

            var expected = "Your change is:\n" +
                "1 x £10\n" +
                "2 x 20p\n" +
                "1 x 2p\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _changeDisplayer.Dispalychange(changeBreakdown);
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void DisplayChange_ShouldReturnEmpty_WhenNull()
        {
            Dictionary<string, int> changeBreakdown = new Dictionary<string, int>();


            var expected = "Your change is:\n";


            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _changeDisplayer.Dispalychange(changeBreakdown);
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.AreEqual(expected, result);
            }

        }

    }
}
