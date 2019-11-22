using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Project;

namespace DocumentIndexerUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests for valid document extension.
        /// </summary>
        [TestMethod]
        public void TestForValidExtension()
        {
            string fileLocation = @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Textbooks\VisualC2012HowtoProgramPaulDeitel-HarveyDeitel5thEditionPrenticeHall2014.pdf";
            Indexer ind_obj = new Indexer();

            bool validExtension = ind_obj.CheckExtension(fileLocation);

            Assert.AreEqual(validExtension, true);
        }

        /// <summary>
        /// Tests for invalid document extension.
        /// </summary>
        [TestMethod]
        public void TestForInvalidExtension()
        {
            string fileLocation = @"C:\Users\Sunkanmi\Documents\web pages(html)\Style.css";
            Indexer ind_obj = new Indexer();

            bool invalidExtension = ind_obj.CheckExtension(fileLocation);

            Assert.AreEqual(invalidExtension, false);
        }

        /// <summary>
        /// Tests for number input.
        /// </summary>
        [TestMethod]
        public void TestForNumberInput()
        {
            //Still needs to be worked on.
            int age = 10;
            Indexer ind_obj = new Indexer();

            bool wrongInput = ind_obj.CheckExtension("10");

            Assert.AreEqual(wrongInput, false);
        }

        /// <summary>
        /// Tests for boolean input.
        /// </summary>
        [TestMethod]
        public void TestForBooleanInput()
        {
            //Still needs to be worked on.
            bool isWritingSomeCode = true;
            Indexer ind_obj = new Indexer();

            bool wrongInput = ind_obj.CheckExtension(@"true");

            Assert.AreEqual(wrongInput, false);
        }
    }
}
