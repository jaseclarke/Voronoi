namespace SimpleVoronoi
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numberOfPoints = new System.Windows.Forms.NumericUpDown();
            this.fillCB = new System.Windows.Forms.CheckBox();
            this.showOutlines = new System.Windows.Forms.CheckBox();
            this.showPoints = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.saveButton);
            this.splitContainer1.Panel1.Controls.Add(this.showPoints);
            this.splitContainer1.Panel1.Controls.Add(this.showOutlines);
            this.splitContainer1.Panel1.Controls.Add(this.fillCB);
            this.splitContainer1.Panel1.Controls.Add(this.numberOfPoints);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numberOfPoints
            // 
            this.numberOfPoints.Location = new System.Drawing.Point(32, 62);
            this.numberOfPoints.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfPoints.Name = "numberOfPoints";
            this.numberOfPoints.Size = new System.Drawing.Size(120, 20);
            this.numberOfPoints.TabIndex = 1;
            this.numberOfPoints.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // fillCB
            // 
            this.fillCB.AutoSize = true;
            this.fillCB.Location = new System.Drawing.Point(32, 101);
            this.fillCB.Name = "fillCB";
            this.fillCB.Size = new System.Drawing.Size(80, 17);
            this.fillCB.TabIndex = 2;
            this.fillCB.Text = "Fill Regions";
            this.fillCB.UseVisualStyleBackColor = true;
            // 
            // showOutlines
            // 
            this.showOutlines.AutoSize = true;
            this.showOutlines.Location = new System.Drawing.Point(32, 124);
            this.showOutlines.Name = "showOutlines";
            this.showOutlines.Size = new System.Drawing.Size(94, 17);
            this.showOutlines.TabIndex = 3;
            this.showOutlines.Text = "Show Outlines";
            this.showOutlines.UseVisualStyleBackColor = true;
            // 
            // showPoints
            // 
            this.showPoints.AutoSize = true;
            this.showPoints.Location = new System.Drawing.Point(32, 147);
            this.showPoints.Name = "showPoints";
            this.showPoints.Size = new System.Drawing.Size(85, 17);
            this.showPoints.TabIndex = 4;
            this.showPoints.Text = "Show Points";
            this.showPoints.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(32, 184);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox fillCB;
        private System.Windows.Forms.NumericUpDown numberOfPoints;
        private System.Windows.Forms.CheckBox showPoints;
        private System.Windows.Forms.CheckBox showOutlines;
        private System.Windows.Forms.Button saveButton;
    }
}

