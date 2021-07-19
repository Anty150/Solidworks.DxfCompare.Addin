
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
            this.startProgram = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Button();
            this.directoryBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // startProgram
            // 
            this.startProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startProgram.Location = new System.Drawing.Point(3, 99);
            this.startProgram.Name = "startProgram";
            this.startProgram.Size = new System.Drawing.Size(105, 48);
            this.startProgram.TabIndex = 0;
            this.startProgram.Text = "button1";
            this.startProgram.UseVisualStyleBackColor = true;
            this.startProgram.Click += new System.EventHandler(this.startProgram_Click);
            // 
            // selectPath
            // 
            this.selectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectPath.Location = new System.Drawing.Point(237, 99);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(105, 48);
            this.selectPath.TabIndex = 1;
            this.selectPath.Text = "button2";
            this.selectPath.UseVisualStyleBackColor = true;
            this.selectPath.Click += new System.EventHandler(this.selectPath_Click);
            // 
            // directoryBox
            // 
            this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryBox.Location = new System.Drawing.Point(3, 12);
            this.directoryBox.Name = "directoryBox";
            this.directoryBox.Size = new System.Drawing.Size(339, 20);
            this.directoryBox.TabIndex = 2;
            this.directoryBox.TextChanged += new System.EventHandler(this.directoryBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 212);
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
            // TaskpaneHostUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.directoryBox);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.startProgram);
            this.Name = "TaskpaneHostUI";
            this.Size = new System.Drawing.Size(347, 627);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startProgram;
        private System.Windows.Forms.Button selectPath;
        private System.Windows.Forms.TextBox directoryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
