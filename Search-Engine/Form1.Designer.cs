namespace Search_Engine
{
    partial class Form1
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
            this.addFiles = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.performanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(627, 110);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(147, 39);
            this.addFiles.TabIndex = 0;
            this.addFiles.Text = "Add files";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.AddFiles_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(131, 224);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(147, 39);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(131, 124);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(399, 25);
            this.inputBox.TabIndex = 2;
            this.inputBox.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(131, 293);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(399, 137);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(356, 25);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(211, 44);
            this.Title.TabIndex = 4;
            this.Title.Text = "Search Engine";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // performanceLabel
            // 
            this.performanceLabel.AutoSize = true;
            this.performanceLabel.Location = new System.Drawing.Point(128, 178);
            this.performanceLabel.Name = "performanceLabel";
            this.performanceLabel.Size = new System.Drawing.Size(97, 17);
            this.performanceLabel.TabIndex = 7;
            this.performanceLabel.Text = "Performance: ";
            this.performanceLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 500);
            this.Controls.Add(this.performanceLabel);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.addFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label performanceLabel;
    }
}

