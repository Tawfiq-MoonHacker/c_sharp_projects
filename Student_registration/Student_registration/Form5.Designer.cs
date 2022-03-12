
namespace Student_registration
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.pdfreader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdfreader)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfreader
            // 
            this.pdfreader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfreader.Enabled = true;
            this.pdfreader.Location = new System.Drawing.Point(0, 0);
            this.pdfreader.Name = "pdfreader";
            this.pdfreader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfreader.OcxState")));
            this.pdfreader.Size = new System.Drawing.Size(800, 450);
            this.pdfreader.TabIndex = 0;
            this.pdfreader.OnError += new System.EventHandler(this.pdfreader_OnError);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pdfreader);
            this.Name = "Form5";
            this.Text = "Student Schedule";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdfreader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF pdfreader;
    }
}