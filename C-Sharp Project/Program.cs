using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Project
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Indexer ind_obj = new Indexer();
            string[] docLocs = { @"./RandomDocs/About yourself.txt", @"./RandomDocs/Spaghetti.txt"
             };

            Dictionary<string, string> invInd = ind_obj.DocumentInvertedIndexer(docLocs);

            foreach (KeyValuePair<string, string> item in invInd)
            {
                Console.WriteLine("Keys: {0} Values: {1}", item.Key, item.Value);
            }

            Console.ReadLine();
        }
    }
}
