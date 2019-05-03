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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteEdit = new System.Windows.Forms.RadioButton();
            this.addEdit = new System.Windows.Forms.RadioButton();
            this.noneEdit = new System.Windows.Forms.RadioButton();
            this.reColourBtn = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.showPoints = new System.Windows.Forms.CheckBox();
            this.showOutlines = new System.Windows.Forms.CheckBox();
            this.fillCB = new System.Windows.Forms.CheckBox();
            this.numberOfPoints = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.minimumColRB = new System.Windows.Forms.RadioButton();
            this.randomColCB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.reColourBtn);
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 520);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteEdit);
            this.groupBox1.Controls.Add(this.addEdit);
            this.groupBox1.Controls.Add(this.noneEdit);
            this.groupBox1.Location = new System.Drawing.Point(32, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Points";
            // 
            // deleteEdit
            // 
            this.deleteEdit.AutoSize = true;
            this.deleteEdit.Location = new System.Drawing.Point(6, 65);
            this.deleteEdit.Name = "deleteEdit";
            this.deleteEdit.Size = new System.Drawing.Size(88, 17);
            this.deleteEdit.TabIndex = 2;
            this.deleteEdit.TabStop = true;
            this.deleteEdit.Text = "Delete Points";
            this.deleteEdit.UseVisualStyleBackColor = true;
            // 
            // addEdit
            // 
            this.addEdit.AutoSize = true;
            this.addEdit.Location = new System.Drawing.Point(6, 42);
            this.addEdit.Name = "addEdit";
            this.addEdit.Size = new System.Drawing.Size(76, 17);
            this.addEdit.TabIndex = 1;
            this.addEdit.TabStop = true;
            this.addEdit.Text = "Add Points";
            this.addEdit.UseVisualStyleBackColor = true;
            // 
            // noneEdit
            // 
            this.noneEdit.AutoSize = true;
            this.noneEdit.Checked = true;
            this.noneEdit.Location = new System.Drawing.Point(6, 19);
            this.noneEdit.Name = "noneEdit";
            this.noneEdit.Size = new System.Drawing.Size(51, 17);
            this.noneEdit.TabIndex = 0;
            this.noneEdit.TabStop = true;
            this.noneEdit.Text = "None";
            this.noneEdit.UseVisualStyleBackColor = true;
            // 
            // reColourBtn
            // 
            this.reColourBtn.Location = new System.Drawing.Point(32, 223);
            this.reColourBtn.Name = "reColourBtn";
            this.reColourBtn.Size = new System.Drawing.Size(94, 23);
            this.reColourBtn.TabIndex = 6;
            this.reColourBtn.Text = "New Colours";
            this.reColourBtn.UseVisualStyleBackColor = true;
            this.reColourBtn.Click += new System.EventHandler(this.ReColourBtn_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(596, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.minimumColRB);
            this.groupBox2.Controls.Add(this.randomColCB);
            this.groupBox2.Location = new System.Drawing.Point(32, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colours";
            // 
            // minimumColRB
            // 
            this.minimumColRB.AutoSize = true;
            this.minimumColRB.Location = new System.Drawing.Point(6, 42);
            this.minimumColRB.Name = "minimumColRB";
            this.minimumColRB.Size = new System.Drawing.Size(66, 17);
            this.minimumColRB.TabIndex = 1;
            this.minimumColRB.TabStop = true;
            this.minimumColRB.Text = "Minimum";
            this.minimumColRB.UseVisualStyleBackColor = true;
            // 
            // randomColCB
            // 
            this.randomColCB.AutoSize = true;
            this.randomColCB.Checked = true;
            this.randomColCB.Location = new System.Drawing.Point(6, 19);
            this.randomColCB.Name = "randomColCB";
            this.randomColCB.Size = new System.Drawing.Size(65, 17);
            this.randomColCB.TabIndex = 0;
            this.randomColCB.TabStop = true;
            this.randomColCB.Text = "Random";
            this.randomColCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button reColourBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton deleteEdit;
        private System.Windows.Forms.RadioButton addEdit;
        private System.Windows.Forms.RadioButton noneEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton minimumColRB;
        private System.Windows.Forms.RadioButton randomColCB;
    }
}

