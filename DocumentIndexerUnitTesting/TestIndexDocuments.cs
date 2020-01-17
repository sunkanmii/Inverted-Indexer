using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Project;
using System.Collections.Generic;
using System.Linq; 

namespace DocumentIndexerUnitTesting
{
    [TestClass]
    public class TestIndexDocuments
    {
        [TestMethod]
        public void TestIndexDocuments1()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt",
            };
                
            Dictionary<string, Dictionary<string, int>> DocumentIndexes = ind_obj.IndexDocuments(documents);

            Dictionary<string, int> firstDoc = DocumentIndexes.Values.ElementAt(0);

            Assert.AreEqual(firstDoc.Keys.ElementAt(0), "hi");            
        }

        [TestMethod]
        public void TestIndexDocuments2()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt",
            };

            Dictionary<string, Dictionary<string, int>> DocumentIndexes = ind_obj.IndexDocuments(documents);

            Dictionary<string, int> firstDoc = DocumentIndexes.Values.ElementAt(0);

            Assert.AreEqual(firstDoc.Keys.ElementAt(2), "fafowora"); 
        }

        [TestMethod]
        public void TestIndexDocuments3()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt",
            };

            Dictionary<string, Dictionary<string, int>> DocumentIndexes = ind_obj.IndexDocuments(documents);
            Dictionary<string, int> secondDoc = DocumentIndexes.Values.ElementAt(1);

            Assert.AreEqual(secondDoc.Keys.ElementAt(1), "rich");
        }

        [TestMethod]
        public void TestIndexDocuments4()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt",
            };

            Dictionary<string, Dictionary<string, int>> DocumentIndexes = ind_obj.IndexDocuments(documents);
            Dictionary<string, int> secondDoc = DocumentIndexes.Values.ElementAt(1);

            Assert.AreEqual(secondDoc.Keys.ElementAt(2), "nature");
        }

    }
}
