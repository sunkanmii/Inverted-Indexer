using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine
{
    public class MatchingFunction
    {
        public List<string> MatchInput(string input, Dictionary<string, string> InvertedIndex)
        {
            Indexer ind_obj = new Indexer();

            Dictionary<string, string> words = InvertedIndex;

            List<string> matchedDocs = new List<string>();

            if (words.ContainsKey(input))
            {
                String wordFound = words[input];
                wordFound.Trim();
                int indOfdocId = words["carbohydrate"].IndexOf("I");
                String oldWord = wordFound;

                // indOfdocId + 1 to remove documentId completely
                String docId = wordFound.Substring(indOfdocId + 1, wordFound.IndexOf("O") - (indOfdocId + 1));
                string occsInDoc = wordFound.Substring(wordFound.IndexOf("O"));

                int indOfCol = docId.IndexOf(":") + 1;
                int lastInd = docId.Length - 1;
                int occsIndCol = occsInDoc.IndexOf(":") + 1;

                //Don't include s
                docId.Trim();
                docId = docId.Substring(indOfCol, lastInd - indOfCol);
                occsInDoc.Trim();
                occsInDoc = occsInDoc.Substring(occsIndCol);


                string[] tempDocumentIds;
                string[] tempOccs;
                string singleDocumentId;
                string singleOcc;
                string tempMatchedDoc;

                if (docId.Contains(","))
                {
                    tempDocumentIds = docId.Split(',');
                    tempOccs = occsInDoc.Split(',');

                    int[] documentIds = new int[tempDocumentIds.Length];
                    int[] occs = new int[tempOccs.Length];

                    for (int i = 0; i < tempDocumentIds.Length; i++)
                    {
                        documentIds[i] = Convert.ToInt32(tempDocumentIds[i]);
                        occs[i] = Convert.ToInt32(tempOccs[i]);
                    }

                    List<int> newOccs = new List<int>(occs);

                    int highest = 0;
                    int indHighest = 0;

                    for (int i = documentIds.Length - 1; i >= 0; i--)
                    {
                        highest = newOccs.Max();
                        indHighest = newOccs.IndexOf(highest);
                        tempMatchedDoc = Convert.ToString(indHighest + 1);
                        matchedDocs.Add(tempMatchedDoc);

                        newOccs[newOccs.IndexOf(highest)] = 0;
                    }

                }
                else
                {
                    singleDocumentId = docId;
                    singleOcc = occsInDoc;
                    matchedDocs.Add(Convert.ToString((docId)));
                }

                return matchedDocs;
            }
            else
            {
                matchedDocs.Add("Not Found");
                return matchedDocs;
            }
        }

    }
}
  
