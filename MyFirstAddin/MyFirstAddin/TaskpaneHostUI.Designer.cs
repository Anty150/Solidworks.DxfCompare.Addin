
namespace MyFirstAddin
{
    partial class TaskpaneHostUI
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startProgram = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Button();
            this.directoryBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Data = new System.Windows.Forms.GroupBox();
            this.Result = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Operation = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.createTxt = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wholeContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyGeometryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Data.SuspendLayout();
            this.Result.SuspendLayout();
            this.Operation.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startProgram
            // 
            this.startProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startProgram.Location = new System.Drawing.Point(9, 96);
            this.startProgram.Name = "startProgram";
            this.startProgram.Size = new System.Drawing.Size(105, 48);
            this.startProgram.TabIndex = 0;
            this.startProgram.Text = "Compare";
            this.toolTip.SetToolTip(this.startProgram, "Click to Compare");
            this.startProgram.UseVisualStyleBackColor = true;
            this.startProgram.Click += new System.EventHandler(this.startProgram_Click);
            // 
            // selectPath
            // 
            this.selectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPath.Location = new System.Drawing.Point(228, 96);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(105, 48);
            this.selectPath.TabIndex = 1;
            this.selectPath.Text = "Path";
            this.toolTip.SetToolTip(this.selectPath, "Click to select Path");
            this.selectPath.UseVisualStyleBackColor = true;
            this.selectPath.Click += new System.EventHandler(this.selectPath_Click);
            // 
            // directoryBox
            // 
            this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryBox.Location = new System.Drawing.Point(3, 42);
            this.directoryBox.Name = "directoryBox";
            this.directoryBox.Size = new System.Drawing.Size(339, 20);
            this.directoryBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.directoryBox, "Path to designated folder");
            this.directoryBox.TextChanged += new System.EventHandler(this.directoryBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Data
            // 
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.Controls.Add(this.startProgram);
            this.Data.Controls.Add(this.selectPath);
            this.Data.Location = new System.Drawing.Point(3, 3);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(339, 186);
            this.Data.TabIndex = 4;
            this.Data.TabStop = false;
            this.Data.Text = "Data";
            this.Data.Enter += new System.EventHandler(this.Data_Enter);
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.Controls.Add(this.label1);
            this.Result.Location = new System.Drawing.Point(3, 195);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(339, 237);
            this.Result.TabIndex = 5;
            this.Result.TabStop = false;
            this.Result.Text = "Result";
            this.toolTip.SetToolTip(this.Result, "After finshed comparision \r\nyour result should be here");
            this.Result.Enter += new System.EventHandler(this.Result_Enter);
            // 
            // Operation
            // 
            this.Operation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Operation.Controls.Add(this.createTxt);
            this.Operation.Location = new System.Drawing.Point(3, 438);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(339, 186);
            this.Operation.TabIndex = 6;
            this.Operation.TabStop = false;
            this.Operation.Text = "Operations";
            this.toolTip.SetToolTip(this.Operation, "Additional operations,\r\npossible after comparision");
            this.Operation.Enter += new System.EventHandler(this.Operation_Enter);
            // 
            // createTxt
            // 
            this.createTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTxt.Location = new System.Drawing.Point(9, 82);
            this.createTxt.Name = "createTxt";
            this.createTxt.Size = new System.Drawing.Size(105, 44);
            this.createTxt.TabIndex = 4;
            this.createTxt.Text = "Create .txt file";
            this.toolTip.SetToolTip(this.createTxt, "Create .txt file with duplicates names \r\nin your path folder");
            this.createTxt.UseVisualStyleBackColor = true;
            this.createTxt.Click += new System.EventHandler(this.createTxt_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wholeContentToolStripMenuItem,
            this.onlyGeometryDataToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // wholeContentToolStripMenuItem
            // 
            this.wholeContentToolStripMenuItem.Name = "wholeContentToolStripMenuItem";
            this.wholeContentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wholeContentToolStripMenuItem.Text = "Whole content";
            this.wholeContentToolStripMenuItem.Click += new System.EventHandler(this.wholeContentToolStripMenuItem_Click);
            // 
            // onlyGeometryDataToolStripMenuItem
            // 
            this.onlyGeometryDataToolStripMenuItem.Name = "onlyGeometryDataToolStripMenuItem";
            this.onlyGeometryDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.onlyGeometryDataToolStripMenuItem.Text = "Only geometry data";
            this.onlyGeometryDataToolStripMenuItem.Click += new System.EventHandler(this.onlyGeometryDataToolStripMenuItem_Click);
            // 
            // TaskpaneHostUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Operation);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.directoryBox);
            this.Controls.Add(this.Data);
            this.Name = "TaskpaneHostUI";
            this.Size = new System.Drawing.Size(347, 627);
            this.Data.ResumeLayout(false);
            this.Result.ResumeLayout(false);
            this.Result.PerformLayout();
            this.Operation.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startProgram;
        private System.Windows.Forms.Button selectPath;
        private System.Windows.Forms.TextBox directoryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox Data;
        private System.Windows.Forms.GroupBox Result;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox Operation;
        private System.Windows.Forms.Button createTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wholeContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyGeometryDataToolStripMenuItem;
    }
}
