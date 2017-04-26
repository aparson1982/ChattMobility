namespace ChattMob
{
    partial class CMServiceManager
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
            this.FetchJobs = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FetchJobs
            // 
            this.FetchJobs.BackColor = System.Drawing.Color.SteelBlue;
            this.FetchJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FetchJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FetchJobs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FetchJobs.Location = new System.Drawing.Point(12, 12);
            this.FetchJobs.Name = "FetchJobs";
            this.FetchJobs.Size = new System.Drawing.Size(141, 32);
            this.FetchJobs.TabIndex = 0;
            this.FetchJobs.Text = "Fetch New Jobs";
            this.FetchJobs.UseVisualStyleBackColor = false;
            this.FetchJobs.Click += new System.EventHandler(this.FetchJobs_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchBtn.Location = new System.Drawing.Point(385, 12);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(141, 32);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(532, 18);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(162, 26);
            this.searchBox.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(580, 239);
            this.textBox1.TabIndex = 4;
            // 
            // CMServiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.FetchJobs);
            this.Name = "CMServiceManager";
            this.Text = "CMServiceManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FetchJobs;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

