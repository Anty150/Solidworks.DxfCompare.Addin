using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Linq;

namespace MyFirstAddin
{
    [ProgId(Main.SWTASKPANE_PROGID)]
    public partial class TaskpaneHostUI : UserControl
    {
        public TaskpaneHostUI()
        {
            InitializeComponent();
            label1.Text = "";

        }
        #region [DataButtons]
        private void startProgram_Click(object sender, EventArgs e)
        {
            if (directoryBox.Text != "")
            {
                Button btnSender = (Button)sender;
                Point ptLowerLeft = new Point(0, btnSender.Height);
                ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
                contextMenuStrip1.Show(ptLowerLeft);
            }
            else
            {
                MessageBox.Show("Path is empty!", "Error");
            }
             
        }

        private void selectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select Folder";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                directoryBox.Text = fbd.SelectedPath;
            }
        }
        #endregion
        #region [CompareFuntion]
        private void GetFileSizeAndCompare(int mode)
        {
            #region [variables]
            int i = 0;
            int g = 0;
            #endregion
            #region [arraysAndLists]
            string[] files = Directory.GetFiles(directoryBox.Text, "*.dxf");
            List<int> duplicatesIndex = new List<int>();
            List<string> duplicatesNames = new List<string>();
            string[] fileNames = new string[files.Length];
            long[] fileSizes = new long[files.Length];
            #endregion
            #region [importingFileSize]
            foreach (var file in files)
            {
                fileNames[i] = file;
                i++;
            }
            for (int j = 0; j < files.Length; j++)
            {
                string fileName = fileNames[j];
                FileInfo fi = new FileInfo(fileName);

                long size = fi.Length;
                fileSizes[j] = size;
            }
            #endregion
            #region [findingPotentialDuplicates]
            for (int j = 0; j < files.Length; j++)
            {
                for (int k = 0; k < files.Length; k++)
                {
                    if (j != k)
                    {
                        if (fileSizes[j] == fileSizes[k])
                        {
                            duplicatesIndex.Add(k);
                            g++;
                        }
                    }
                }
            }
            #endregion
            #region [finingDuplicates]
            for (int j = 0; j < duplicatesIndex.Count; j++)
            {
                for (int k = 0; k < duplicatesIndex.Count; k++)
                {
                    if (j != k)
                    {
                        if(mode == 1)
                        {
                            if (ReadFile(fileNames[duplicatesIndex[j]], fileNames[duplicatesIndex[k]]))
                            {
                                label1.Text += "Duplicate found: \n" + fileNames[duplicatesIndex[j]] + " \n is a duplicate of \n" + fileNames[duplicatesIndex[k]] + "\n";
                                duplicatesNames.Add(fileNames[duplicatesIndex[j]]);
                                duplicatesNames.Add(fileNames[duplicatesIndex[k]]);
                                duplicatesIndex.RemoveAt(k);
                            }
                        }
                        else
                        {
                            if (ReadFileGeoOnly(fileNames[duplicatesIndex[j]], fileNames[duplicatesIndex[k]]))
                            {
                                label1.Text += "Duplicate found: \n" + fileNames[duplicatesIndex[j]] + " \n is a duplicate of \n" + fileNames[duplicatesIndex[k]] + "\n";
                                duplicatesNames.Add(fileNames[duplicatesIndex[j]]);
                                duplicatesNames.Add(fileNames[duplicatesIndex[k]]);
                                duplicatesIndex.RemoveAt(k);
                            }
                        }                        
                    }
                }
            }
            #endregion
            #region [Optional duplicates remove]                        
            if (duplicatesNames.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove duplicates?", "Remove duplicates", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int deleted = 0;
                    for (int o = 0; o < duplicatesNames.Count; o++)
                    {
                        if (o != 0)
                        {
                            if (o % 2 != 0)
                            {
                                File.Delete(duplicatesNames[o]);
                                deleted++;
                            }
                        }
                    }
                    duplicatesNames.Clear();
                    MessageBox.Show("Successfully deleted " + deleted + " files", "Succes");
                    label1.Text += "\nDeleted " + deleted + " files!";

                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Duplicates not found!", "Result");
                label1.Text = "Duplicates not found!";
            }
            #endregion
        }
        #endregion
        #region [ReadFile Functions]
        private bool ReadFile(string dir, string dir2)
        {
            //For dir1
            File.Copy(dir, Path.ChangeExtension(dir, ".txt"));
            string directory1 = Path.ChangeExtension(dir, ".txt");
            //label1.Text = directory1; #Debug
            //For dir2
            File.Copy(dir2, Path.ChangeExtension(dir2, ".txt"));
            string directory2 = Path.ChangeExtension(dir2, ".txt");
            //label1.Text = directory2; #Debug           
            //Read file1
            StreamReader reader;
            reader = new StreamReader(directory1);
            string Data1 = reader.ReadToEnd();
            reader.Close();
            //Read file2
            reader = new StreamReader(directory2);
            string Data2 = reader.ReadToEnd();
            reader.Close();
            if (Data1 == Data2)
            {
                File.Delete(directory1);
                File.Delete(directory2);
                return true;
            }
            else
            {
                File.Delete(directory1);
                File.Delete(directory2);
                return false;
            }
        }
        private bool ReadFileGeoOnly(string dir, string dir2)
        {
            //For dir1
            File.Copy(dir, Path.ChangeExtension(dir, ".txt"));
            string directory1 = Path.ChangeExtension(dir, ".txt");
            //label1.Text = directory1; #Debug
            //For dir2
            File.Copy(dir2, Path.ChangeExtension(dir2, ".txt"));
            string directory2 = Path.ChangeExtension(dir2, ".txt");
            //label1.Text = directory2; #Debug           

            string data1 = "";
            string linedata1 = "";
            string data2 = "";
            string linedata2 = "";
            using (StreamReader file = new StreamReader(directory1))
            {
                int counter = 0;
                string ln;
                int lineNumber = -1;
                while ((ln = file.ReadLine()) != null && lineNumber != -1)
                {
                    if(ln == "ENTITIES")
                    {
                        lineNumber = counter;
                    }
                    counter++;
                }
                while (linedata1 != "ENDSEC")
                {
                    data1 += File.ReadLines(directory1).Skip(lineNumber - 1).Take(1).First();
                    linedata1 = File.ReadLines(directory1).Skip(lineNumber - 1).Take(1).First();
                    lineNumber++;
                }
                file.Close();
            }
            using (StreamReader file = new StreamReader(directory2))
            {
                int counter = 0;
                string ln;
                int lineNumber = -1;
                while ((ln = file.ReadLine()) != null && lineNumber != -1)
                {
                    if (ln == "ENTITIES")
                    {
                        lineNumber = counter;
                    }
                    counter++;
                }
                while (linedata2 != "ENDSEC")
                {
                    data2 += File.ReadLines(directory2).Skip(lineNumber - 1).Take(1).First();
                    linedata2 = File.ReadLines(directory2).Skip(lineNumber - 1).Take(1).First();
                    lineNumber++;
                }
                file.Close();
            }
            if(data1 == data2)
            {
                File.Delete(directory1);
                File.Delete(directory2);
                return true;
            }
            else
            {
                File.Delete(directory1);
                File.Delete(directory2);
                return false;
            }
        }
        #endregion
        #region [OperationsButtons]
        private void CreateTextFile()
        {
            string fileName = directoryBox.Text + @"\raport.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] duplicate = new UTF8Encoding(true).GetBytes(label1.Text);
                    fs.Write(duplicate, 0, duplicate.Length);


                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            MessageBox.Show("Successfully created text file with duplicates names at " + fileName + "!", "Succes");
        }
        private void createTxt_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                CreateTextFile();
            }
            else
            {
                MessageBox.Show("Comparision has not been performed!", "Error");
            }
        }
        #endregion
        #region [ToolstripMenu]        
        private void wholeContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            GetFileSizeAndCompare(1);
        }

        private void onlyGeometryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            GetFileSizeAndCompare(2);
        }
        #endregion
        #region [Empty functions]       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Data_Enter(object sender, EventArgs e)
        {

        }
        private void Result_Enter(object sender, EventArgs e)
        {

        }

        private void Operation_Enter(object sender, EventArgs e)
        {

        }

        private void directoryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion
    }

}
