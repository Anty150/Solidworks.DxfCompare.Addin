using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace MyFirstAddin
{
    [ProgId(Main.SWTASKPANE_PROGID)]
    public partial class TaskpaneHostUI : UserControl
    {
       
        public TaskpaneHostUI()
        {
            InitializeComponent();
        }

        private void startProgram_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            GetFileSize();
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

        private void directoryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        
        private void GetFileSize()
        {
            string[] files = Directory.GetFiles(directoryBox.Text, "*.dxf");
            int i = 0;
            int g = 0;
            List<int> duplicatesIndex = new List<int>();
            string[] fileNames = new string[files.Length];
            long[] fileSizes = new long[files.Length];            
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
            for (int j = 0; j < duplicatesIndex.Count; j++)
            {
                //label1.Text += fileNames[duplicatesIndex[j]] + "\n"; #Debug
            }


            //Comparing files
            for (int j = 0; j < duplicatesIndex.Count; j++)
            {
                for (int k = 0; k < duplicatesIndex.Count; k++)
                {
                    if (j != k)
                    {
                        if (ReadFile(fileNames[duplicatesIndex[j]], fileNames[duplicatesIndex[k]]))
                        {
                            label1.Text += "\n Wykryto duplikat: \n" + fileNames[duplicatesIndex[j]] + " \n to duplikat pliku \n" + fileNames[duplicatesIndex[k]];
                            duplicatesIndex.RemoveAt(k);
                        }
                    }
                }
            }            

        }
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

    }
   
}
