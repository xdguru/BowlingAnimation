
namespace ChavetBowling
{
    partial class Ecran
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
            this.pbTV = new System.Windows.Forms.PictureBox();
            this.bCreateScence = new System.Windows.Forms.Button();
            this.bThrow = new System.Windows.Forms.Button();
            this.bClearScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTV
            // 
            this.pbTV.Location = new System.Drawing.Point(12, 11);
            this.pbTV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbTV.Name = "pbTV";
            this.pbTV.Size = new System.Drawing.Size(1000, 500);
            this.pbTV.TabIndex = 1;
            this.pbTV.TabStop = false;
            // 
            // bCreateScence
            // 
            this.bCreateScence.Location = new System.Drawing.Point(12, 523);
            this.bCreateScence.Name = "bCreateScence";
            this.bCreateScence.Size = new System.Drawing.Size(192, 49);
            this.bCreateScence.TabIndex = 18;
            this.bCreateScence.Text = "Create Scene";
            this.bCreateScence.UseVisualStyleBackColor = true;
            this.bCreateScence.Click += new System.EventHandler(this.bCreateScence_Click);
            // 
            // bThrow
            // 
            this.bThrow.Location = new System.Drawing.Point(210, 523);
            this.bThrow.Name = "bThrow";
            this.bThrow.Size = new System.Drawing.Size(93, 49);
            this.bThrow.TabIndex = 19;
            this.bThrow.Text = "Throw";
            this.bThrow.UseVisualStyleBackColor = true;
            this.bThrow.Click += new System.EventHandler(this.bThrow_Click);
            // 
            // bClearScreen
            // 
            this.bClearScreen.Location = new System.Drawing.Point(919, 523);
            this.bClearScreen.Name = "bClearScreen";
            this.bClearScreen.Size = new System.Drawing.Size(93, 49);
            this.bClearScreen.TabIndex = 20;
            this.bClearScreen.Text = "Clear Screen";
            this.bClearScreen.UseVisualStyleBackColor = true;
            this.bClearScreen.Click += new System.EventHandler(this.bClearScreen_Click);
            // 
            // Ecran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 584);
            this.Controls.Add(this.bClearScreen);
            this.Controls.Add(this.bThrow);
            this.Controls.Add(this.bCreateScence);
            this.Controls.Add(this.pbTV);
            this.Name = "Ecran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bowling";
            ((System.ComponentModel.ISupportInitialize)(this.pbTV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTV;
        private System.Windows.Forms.Button bCreateScence;
        private System.Windows.Forms.Button bThrow;
        private System.Windows.Forms.Button bClearScreen;
    }
}

