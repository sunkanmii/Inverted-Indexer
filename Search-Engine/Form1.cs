using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Search_Engine;

namespace Search_Engine
{
    public partial class Form1 : Form
    {
        private static string[] newDocLocs;
        private static List<string> docLocs = new List<string>();
        private static List<string> docsMatched;
        private static List<LinkLabel> cusLinkLabels = new List<LinkLabel>();
        private static Dictionary<string, string> invertedIndex;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.InitialDirectory = @"C:\Users\Sunkanmi\Documents\1) Uni files\300 level\2nd Semester\CSC 322(C#)\Project Materials\Random documents";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //The filter index property is used to set which filtering option is
            //first shown to the user and it starts from one.
            openFileDialog1.FilterIndex = 2;  
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.Multiselect = true;
            
            openFileDialog1.ShowDialog();

            foreach (string file in openFileDialog1.FileNames)
            {
                docLocs.Add(file);
                MessageBox.Show(file);
            }

            newDocLocs = docLocs.ToArray();

            Indexer ind_obj = new Indexer();
            invertedIndex = ind_obj.DocumentInvertedIndexer(newDocLocs);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            MatchingFunction matchObj = new MatchingFunction();

            if (inputBox.Text != "")
            {
                docsMatched = matchObj.MatchInput(inputBox.Text, invertedIndex);
                for (int i = 0; i < docsMatched.Count; i++)
                {
                    cusLinkLabels.Add(new LinkLabel());

                    int doc = 0;
                    if (!(docsMatched[0].Equals("Not Found")))
                    {
                        doc = Convert.ToInt32(docsMatched[i]);
                        cusLinkLabels[i].Font = new Font("Verdana", 10);
                        cusLinkLabels[i].Tag = newDocLocs[doc - 1];
                        cusLinkLabels[i].Text = Path.GetFileName(newDocLocs[doc - 1]);
                        cusLinkLabels[i].Location = new Point(10, 10 * (doc * 2));
                        cusLinkLabels[i].ActiveLinkColor = Color.Orange;
                        cusLinkLabels[i].VisitedLinkColor = Color.Blue;
                        cusLinkLabels[i].LinkColor = Color.RoyalBlue;
                        cusLinkLabels[i].DisabledLinkColor = Color.Gray;
                        cusLinkLabels[i].Links.Add(0, cusLinkLabels[i].Text.Length, cusLinkLabels[i].Tag);
                        cusLinkLabels[i].LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabels__LinkClicked);
                        textBox2.Controls.Add(cusLinkLabels[i]);
                    }
                    else
                    {
                        textBox2.Text = docsMatched[0];
                    }
                }
            }
            else
            {
                textBox2.Text = "No text entered.";
            }
        }
        private void LinkLabels__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //for(int i = 0; i < cusLinkLabels.Count; i++) { 
            //    // CusLinkLabels[i].Links[CusLinkLabels[i].Links.IndexOf(e.Link)].Visited = true;
            //}
            string target = e.Link.LinkData as string;
            textBox2.Text = target;
            ProcessStartInfo pi = new ProcessStartInfo(target);
            pi.Arguments = Path.GetFileName(target);
            pi.UseShellExecute = true;
            pi.WorkingDirectory = Path.GetDirectoryName(target);
            pi.FileName = target;
            pi.Verb = "OPEN";
            Process.Start(pi);
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
