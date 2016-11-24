namespace CollapsibleGroupBoxDemo
{
    partial class MainForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collapsibleGroupBox3 = new System.Windows.Forms.CollapsibleGroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.collapsibleGroupBox1 = new System.Windows.Forms.CollapsibleGroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.collapsibleGroupBox3.SuspendLayout();
            this.collapsibleGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(432, 111);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // collapsibleGroupBox3
            // 
            this.collapsibleGroupBox3.Controls.Add(this.button5);
            this.collapsibleGroupBox3.Controls.Add(this.button4);
            this.collapsibleGroupBox3.Controls.Add(this.button3);
            this.collapsibleGroupBox3.Controls.Add(this.button2);
            this.collapsibleGroupBox3.Controls.Add(this.button1);
            this.collapsibleGroupBox3.DisplayAreaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.collapsibleGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleGroupBox3.ExpandedSize = 62;
            this.collapsibleGroupBox3.Location = new System.Drawing.Point(0, 111);
            this.collapsibleGroupBox3.Name = "collapsibleGroupBox3";
            this.collapsibleGroupBox3.Size = new System.Drawing.Size(432, 62);
            this.collapsibleGroupBox3.TabIndex = 2;
            this.collapsibleGroupBox3.Text = "Animated Footer Groupbox";
            this.collapsibleGroupBox3.TitleBarBorderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(218)))), ((int)(((byte)(254)))));
            this.collapsibleGroupBox3.TitleBarBorderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.collapsibleGroupBox3.TitleBarHoverBorderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(254)))), ((int)(((byte)(175)))));
            this.collapsibleGroupBox3.TitleBarHoverBorderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.collapsibleGroupBox3.TitleBarStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(219)))), ((int)(((byte)(240)))));
            this.collapsibleGroupBox3.TitleFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(336, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // collapsibleGroupBox1
            // 
            this.collapsibleGroupBox1.AnimationStepPercent = 100F;
            this.collapsibleGroupBox1.Controls.Add(this.checkedListBox1);
            this.collapsibleGroupBox1.DisplayAreaBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.collapsibleGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.collapsibleGroupBox1.ExpandedSize = 173;
            this.collapsibleGroupBox1.Location = new System.Drawing.Point(432, 0);
            this.collapsibleGroupBox1.Name = "collapsibleGroupBox1";
            this.collapsibleGroupBox1.Size = new System.Drawing.Size(157, 173);
            this.collapsibleGroupBox1.TabIndex = 1;
            this.collapsibleGroupBox1.Text = "Sidebar Groupbox";
            this.collapsibleGroupBox1.TitleBarBorderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(218)))), ((int)(((byte)(254)))));
            this.collapsibleGroupBox1.TitleBarBorderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.collapsibleGroupBox1.TitleBarEdge = System.Windows.Forms.CollapsibleGroupBoxTitleEdge.Left;
            this.collapsibleGroupBox1.TitleBarHoverBorderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(254)))), ((int)(((byte)(175)))));
            this.collapsibleGroupBox1.TitleBarHoverBorderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.collapsibleGroupBox1.TitleBarStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(219)))), ((int)(((byte)(240)))));
            this.collapsibleGroupBox1.TitleFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6",
            "Item 7",
            "Item 8",
            "Item 9",
            "Item 10"});
            this.checkedListBox1.Location = new System.Drawing.Point(30, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(116, 154);
            this.checkedListBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 173);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.collapsibleGroupBox3);
            this.Controls.Add(this.collapsibleGroupBox1);
            this.Name = "MainForm";
            this.Text = "CollapsibleGroupBox Demo";
            this.collapsibleGroupBox3.ResumeLayout(false);
            this.collapsibleGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CollapsibleGroupBox collapsibleGroupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CollapsibleGroupBox collapsibleGroupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

