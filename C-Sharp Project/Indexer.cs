using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace C_Sharp_Project
{
    public class Indexer
    {
        // Not needed.
        ///// <summary>
        ///// List to store new indexes.
        ///// </summary>
        //static List<int> newIndexes = new List<int>();
        //
        ///// <summary>
        ///// List to store occurrences of indexes.
        ///// </summary>
        //static List<int> indexOccurrence = new List<int>();
        
        /// <summary>
        /// Checks for valid extension file format.
        /// </summary>
        /// <param name="fileLocation">Accepts the location of the file of type string</param>
        /// <returns>True if file extension is valid, and false otherwise.</returns>
        public Boolean CheckExtension(string fileLocation)
        {
            FileInfo fileInfo = new FileInfo(fileLocation);

            string fileExtension = fileInfo.Extension;

            if (fileExtension.Equals(".pdf") || fileExtension.Equals(".doc")
            || fileExtension.Equals(".docx") || fileExtension.Equals(".ppt")
            || fileExtension.Equals(".ppts") || fileExtension.Equals(".xls")
            || fileExtension.Equals(".xlsx") || fileExtension.Equals(".txt")
            || fileExtension.Equals(".html") || fileExtension.Equals(".xml"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Indexes each word and removes reoccurring indexes
        /// of each word.
        /// </summary>
        /// <param name="fileLocation">Accepts the file location string parameter.</param>
        /// <returns>A list of the indexes of each word.</returns>
        public Dictionary<string, int> DocumentIndexer(string fileLocation)
        {
            string[] texts = File.ReadAllLines(fileLocation);

            int texts_length = texts.Length;

            string[][] splittedTexts = new string[texts_length][];

            RemoveStopWords RSW_obj = new RemoveStopWords();

            for (int i = 0; i < texts_length; i++)
            {
                texts[i] = RSW_obj.RemoveStopwords(texts[i]);
            }

            for (int i = 0; i < texts_length; i++)
            {
                splittedTexts[i] = texts[i].Split(' ');
            }

            int splittedTextsLength = splittedTexts.Length;

            List<string> separatedTextsFromFile = new List<string>();

            for (int i = 0; i < splittedTextsLength; i++)
            {
                for (int j = 0; j < splittedTexts[i].Length; j++)
                {
                    separatedTextsFromFile.Add(splittedTexts[i][j].ToLower());
                }
            }

            int separatedTextsFromFile_length = separatedTextsFromFile.Count;
            List<int> indexesOfTexts = new List<int>();
            List<string> textsFromFile = new List<string>();
            List<int> newIndexes = new List<int>();
            List<int> indexOccurrence = new List<int>();

            textsFromFile.Add(separatedTextsFromFile[0]);
            indexesOfTexts.Add(0);
            bool foundSameText = false;

            for (int i = 1; i < separatedTextsFromFile_length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (separatedTextsFromFile[i].Equals(separatedTextsFromFile[j]))
                    {
                        foundSameText = true;
                        indexesOfTexts.Add(j);
                        break;
                    }
                }

                if (foundSameText == true)
                {
                    foundSameText = false;
                    continue;
                }

                indexesOfTexts.Add(i);
                textsFromFile.Add(separatedTextsFromFile[i]);
            }

            int indexesOfTexts_length = indexesOfTexts.Count;
            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < indexesOfTexts_length; i++)
            {
                for (int j = 0; j < newIndexes.Count; j++)
                {
                    if (indexesOfTexts[i] == newIndexes[j])
                    {
                        count1++;
                    }
                }
                if (count1 > 0)
                {
                    count1 = 0;
                    continue;
                }
                for (int j = i; j < indexesOfTexts_length; j++)
                {
                    if (indexesOfTexts[i] == indexesOfTexts[j])
                    {
                        count2++;
                    }
                    if (j == indexesOfTexts_length - 1 && count2 != 0)
                    {
                        indexOccurrence.Add(count2);
                        newIndexes.Add(indexesOfTexts[i]);
                        count2 = 0;
                    }
                }
            }

            Dictionary<string, int> Word_NumberOfOccurrences = new Dictionary<string, int>();

            for (int i = 0; i < textsFromFile.Count; i++)
            {
                Word_NumberOfOccurrences.Add(textsFromFile[i], indexOccurrence[i]);
            }

            return Word_NumberOfOccurrences;
        }
        
        /// <summary>
        /// Creates indexes for multiple documents.
        /// </summary>
        /// <param name="documentLocations">Accepts an array containing 
        /// the locations of each document.</param>
        /// <returns>A dictionary containing each document, words present in each,
        /// and their occurrences.</returns>
        public Dictionary<string, Dictionary<string, int>> IndexDocuments(string[] documentLocations)
        {
            Dictionary<string, Dictionary<string, int>> DocumentsWordsNOccurrence = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < documentLocations.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(documentLocations[i]);

                Dictionary<string, int> WordNOccurrences = DocumentIndexer(documentLocations[i]);

                DocumentsWordsNOccurrence.Add(fileInfo.Name, WordNOccurrences);
            }

            return DocumentsWordsNOccurrence;
        }

        /// <summary>
        /// Creates an inverted index for each document passed.
        /// </summary>
        /// <param name="documents">A dictionary containing each document, words present
        /// in each document, and their occurrences.</param>
        /// <returns>An inverted index of each document.</returns>
        public Dictionary<Dictionary<string, string>, string> InvertedIndexForDocuments(Dictionary<string, Dictionary<string, int>> documents)
        {
            Dictionary<Dictionary<string, string>, string> sortedDocuments = new Dictionary<Dictionary<string, string>, string>();

            Dictionary<Dictionary<string, string>, string> invertedDocswithOccurrences = new Dictionary<Dictionary<string, string>, string>();

            Dictionary<string, Dictionary<string, int>>.ValueCollection stringsNOccurrences = documents.Values;
            int temp_itr = 0;
            
            //String to store document ids of word
            //occurring in more than one document.
            string documentIds = "";

            foreach (Dictionary<string, int> item in stringsNOccurrences)
            {
                Dictionary<string, string> tempDict = new Dictionary<string, string>();

                string[] arr = new string[item.Count];
                 
                for (int i = 0; i < item.Count; i++)
                {
                    arr[i] = item.Keys.ElementAt(i);
                }

                //Calling counting sort here.
                CountingSort.CountSort(arr);

                for (int i = 0; i < item.Count; i++)
                {
                    tempDict.Add(arr[i], Convert.ToString(item[arr[i]]));
                    arr[i] = "";
                }

                for (int i = 0; i < 1; i++)
                {
                    //Order - Word, occurrences and document id
                    //(i.e first document has an id of 1, second 2, etc.)
                    sortedDocuments.Add(tempDict, Convert.ToString(temp_itr + 1));
                }

                temp_itr++;
            }

            Dictionary<Dictionary<string, string>, string>.KeyCollection tempDic = sortedDocuments.Keys;
            Dictionary<string, string>[] stringKeyCollection = new Dictionary<string, string>[tempDic.Count];
            
            string value = "";
            int itr = 0;
            foreach (Dictionary<string, string> item in tempDic)
            {
                stringKeyCollection[itr] = item;
                itr++;
            }

            for (int i = 0; i < tempDic.Count - 1; i++)
            {
                for (int j = i + 1; j < tempDic.Count; j++)
                {
                    Dictionary<string, string>.KeyCollection tempStringDic = stringKeyCollection[j].Keys;
                    foreach (string item in tempStringDic.ToList())
                    {
                        if (stringKeyCollection[i].TryGetValue(item, out value))
                        {
                            string oldValue = stringKeyCollection[i][item];
                            string nextDocValue = stringKeyCollection[j][item];

                            stringKeyCollection[i][item] = oldValue + "," + nextDocValue;

                            stringKeyCollection[j].Remove(item);

                            string newValueForKey = stringKeyCollection[i][item];

                            //For each item you find reoccurring in the
                            //next document.

                            if(j == (i + 1))
                            {
                                documentIds = " documentIds:" + (i + 1) + "," + (j + 1);
                                stringKeyCollection[i][item] = newValueForKey + documentIds;
                            }
                            else
                            {
                                documentIds = documentIds + "," + (j + 1);
                                stringKeyCollection[i][item] = newValueForKey + documentIds;
                            }
                            value = "";
                        }
                        string frequency = ""; 
                    }
                }
                documentIds = "";
            }

            int itr_2 = 0;
            string value_1;
            for (int i = 0; i < stringKeyCollection.Length; i++)
            {
                Dictionary<string, string>.KeyCollection tempStringDic_1 = stringKeyCollection[i].Keys;
                itr_2++;
                foreach (string item in tempStringDic_1.ToList())
                {
                    if (stringKeyCollection[i].TryGetValue(item, out value_1))
                    {
                        string oldValue = stringKeyCollection[i][item];
                        if (oldValue.Contains("documentIds"))
                        {
                            stringKeyCollection[i][item] = "Frequency: "
                            + oldValue.Substring(oldValue.Length - 1, 1) + " " +
                            oldValue.Remove(0, oldValue.IndexOf("documentId")) + " Occurrences: "
                            + oldValue.Substring(0, oldValue.IndexOf(" documentId"));
                        }
                        else
                        {
                            stringKeyCollection[i][item] = "Frequency: 1" +
                            " documentId: " + itr_2 + " Occurrences: " + oldValue;
                        }
                    }
                }
            }

            for (int i = 0; i < stringKeyCollection.Length; i++)
            { 
                invertedDocswithOccurrences.Add(stringKeyCollection[i], Convert.ToString((i + 1)));
            }

            return invertedDocswithOccurrences;
        }

        /// <summary>
        /// Calls other methods of the class 
        /// to obtain the inverted indexes of the documents.
        /// </summary>
        /// <param name="documentLocations">Accepts the documents
        /// locations of each document.</param>
        /// <returns>A dictionary storing the inverted indexes of
        /// the documents.</returns>
        public Dictionary<string, string> DocumentInvertedIndexer(string[] documentLocations)
        {
            Indexer ind_obj = new Indexer();

            Dictionary<string, Dictionary<string, int>> DocumentsWordsNOccurrence = ind_obj.IndexDocuments(documentLocations);

            Dictionary<Dictionary<string, string>, string> invertedIndexedDocuments = ind_obj.InvertedIndexForDocuments(DocumentsWordsNOccurrence);

            Dictionary<Dictionary<string, string>, string>.KeyCollection invertedIndexedDocumentsKeys = invertedIndexedDocuments.Keys;

            Dictionary<string, string> documentsIndexesInverted = new Dictionary<string, string>();
            
            foreach(Dictionary<string, string> item in invertedIndexedDocumentsKeys)
            {
                foreach(KeyValuePair<string, string> element in item)
                {
                    documentsIndexesInverted.Add(element.Key, element.Value);
                }
            }

            int itr = 0;
            string[] arr = new string[documentsIndexesInverted.Count];
            foreach (string item in documentsIndexesInverted.Keys)
            {
                arr[itr] = item;
                itr++;
            }

            CountingSort.CountSort(arr);
            itr = 0;

            Dictionary<string, string> sortedDocumentsIndexesInverted = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in documentsIndexesInverted)
            {
                sortedDocumentsIndexesInverted.Add(arr[itr], documentsIndexesInverted[arr[itr]]);
                itr++;
            }

            return sortedDocumentsIndexesInverted;
        }
    }
}

