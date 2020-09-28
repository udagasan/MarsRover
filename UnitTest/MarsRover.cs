using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class MarsRover
    {
        public Input Input { get; set; } = new Input();
        [TestInitialize]
        public void InitializeTestStatic()
        {
            Input.MaxPoints = new List<int>() { 5, 5 };
        }

        [TestMethod]
        public void When_The_Input_12N_LMLMLMLMM_The_Output_Should_Be_12N()
        {
            //CASE
            Input.Coorinates = new Constants.Coorinates(1, 2);
            Input.Direction = Constants.Directions.North;
            Input.Moves = "LMLMLMLMM";
            //WHEN
            var output = new RoboticRover().Row(Input);

            //THEN

            var expectedOutput = new Output
            {
                Coorinates = new Constants.Coorinates(1, 3),
                Direction = Constants.Directions.North

            };
            Assert.AreSame(expectedOutput.Direction.ToString(), output.Direction.ToString());
            Assert.AreEqual(expectedOutput.Coorinates.X, output.Coorinates.X);
            Assert.AreEqual(expectedOutput.Coorinates.Y, output.Coorinates.Y);
        }

        [TestMethod]
        public void When_The_Input_33E_MRRMMRMRRM_The_Output_Should_Be_51E()
        {
            //CASE
            Input.Coorinates = new Constants.Coorinates(3, 3);
            Input.Direction = Constants.Directions.North;
            Input.Moves = "MRRMMRMRRM";

            //WHEN
            var output = new RoboticRover().Row(Input);

            //THEN
            var expectedOutput = new Output
            {
                Coorinates = new Constants.Coorinates(2, 3),
                Direction = Constants.Directions.South

            };
            Assert.AreSame(expectedOutput.Direction, output.Direction);
            Assert.AreEqual(expectedOutput.Coorinates.X, output.Coorinates.X);
            Assert.AreEqual(expectedOutput.Coorinates.Y, output.Coorinates.Y);
        }
    }
}
