using MarsRoverAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverAlgorithmTests
{
    [TestClass] 
    public class MarsRoverAlgorithmTest
    {
        [TestMethod]
        public void MarsRoverAlgorithmTest1()
        {
            //Robotic rovers inputs must be string type.
            //Outputs are expected string too.
            string input =
@"
8 8
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
3 1 W
RMMRMLMLM
5 1 S
MRMMRMLMLM
";
            string output = new RoverManagement().GetOutput(input.Trim());

            var expectedOutput =
@"
1 3 N
5 1 E
3 4 W
2 0 S
";
            expectedOutput = expectedOutput.Replace("\n", "").Trim();//Ignore \n chars
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
