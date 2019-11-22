using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_Sharp_Project;

namespace DocumentIndexerUnitTesting
{
    [TestClass]
    public class TestRemoveStopWords
    {
        [TestMethod]
        public void TestStopWord1()
        {
            string randomSentence = "C# is cool, but it's not very funny sometimes when you" +
                " encounter an exception.";
            RemoveStopWords RSW_obj = new RemoveStopWords();

            randomSentence = RSW_obj.RemoveStopwords(randomSentence);

            Assert.AreEqual(randomSentence, "C# cool it's funny encounter exception");
        }

        [TestMethod]
        public void TestStopWord2()
        {
            string randomSentence = "It was a dark and stormy night...along a rough terrain " +
                "was a young boy in a cape. (sound effects)";
            RemoveStopWords RSW_obj = new RemoveStopWords();

            randomSentence = RSW_obj.RemoveStopwords(randomSentence);

            Assert.AreEqual(randomSentence, "dark stormy night rough terrain young boy cape (sound effects)");
        }

        [TestMethod]
        public void TestStopWord3()
        {
            string randomSentence = "I am hungry, Samuel and Jide, you two can " +
                "send some money to me :)";
            RemoveStopWords RSW_obj = new RemoveStopWords();

            randomSentence = RSW_obj.RemoveStopwords(randomSentence);

            Assert.AreEqual(randomSentence, "hungry Samuel Jide send money :)");
        }

        [TestMethod]
        public void TestStopWord4()
        {
            string randomSentence = "And I see fire, for-mall-y mountain, I see fire" +
                "...burning something something, but computer cry, describe, what" +
                " you mean o, I am not down, I am found.";
            RemoveStopWords RSW_obj = new RemoveStopWords();

            randomSentence = RSW_obj.RemoveStopwords(randomSentence);

            Assert.AreEqual(randomSentence, "for-mall-y mountain burning mean o");
        }

        [TestMethod]
        public void TestStopWord5()
        {
            string randomSentence = "I think The Flintstones are almost forty years.";
            RemoveStopWords RSW_obj = new RemoveStopWords();

            randomSentence = RSW_obj.RemoveStopwords(randomSentence);

            Assert.AreEqual(randomSentence, "think Flintstones years");
        }
    }
}
