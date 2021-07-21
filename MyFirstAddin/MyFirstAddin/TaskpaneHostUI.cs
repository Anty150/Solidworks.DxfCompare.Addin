using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using SolidWorks.Interop.sldworks;
using Microsoft.VisualBasic;
using SolidWorks.Interop.swconst;

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
            fbd.RootFolder = System.Environment.SpecialFolder.Desktop;
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
                label1.Text += fileNames[duplicatesIndex[j]] + "\n";
            }


            Main.ImportFile(@"C:\Users\01-WRO\Desktop\tmp\pliki\1276_OP_VP2542_20.dxf");
            
        }

    }
   
}
