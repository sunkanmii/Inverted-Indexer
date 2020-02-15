using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Search_Engine;

namespace Search_Engine_Test
{
    [TestClass]
    public class TestDocumentInvertedIndexer
    {

        [TestMethod]
        public void TestInvertedIndexForDocuments1()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt"
            };

            Dictionary<string, Dictionary<string, int>> indexedDocuments = ind_obj.IndexDocuments(documents);

            Dictionary<Dictionary<string, string>, string> invertIndexForDocs = ind_obj.InvertIndexForDocuments(indexedDocuments);

            Dictionary<string, string> firstDoc = invertIndexForDocs.Keys.ElementAt(0);

            Assert.AreEqual(firstDoc.Keys.ElementAt(0), "carbohydrate");
        }

        [TestMethod]
        public void TestInvertedIndexForDocuments2()
        {
            Indexer ind_obj = new Indexer();

            string[] documents = {
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\About yourself.txt",
                @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level files\2nd Semester\CSC 322(C#)\Project Materials\Random documents\Spaghetti.txt"
            };

            Dictionary<string, Dictionary<string, int>> indexedDocuments = ind_obj.IndexDocuments(documents);

            Dictionary<Dictionary<string, string>, string> invertIndexForDocs = ind_obj.InvertIndexForDocuments(indexedDocuments);

            Dictionary<string, string> secondDoc = invertIndexForDocs.Keys.ElementAt(1);

            Assert.AreEqual(secondDoc.Keys.ElementAt(0), "choices");
        }
    }
}
