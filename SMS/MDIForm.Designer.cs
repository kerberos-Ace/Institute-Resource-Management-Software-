namespace SMS
{
    partial class MDIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaulterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cumapingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feeBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feeCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.viewExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arno Pro Smbd Caption", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.courToolStripMenuItem,
            this.batchesToolStripMenuItem,
            this.collegeToolStripMenuItem,
            this.cumapingToolStripMenuItem,
            this.bmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(658, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRecordToolStripMenuItem,
            this.addToolStripMenuItem,
            this.defaulterListToolStripMenuItem,
            this.searchRecordToolStripMenuItem});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(93, 30);
            this.studentsToolStripMenuItem.Text = "Records";
            // 
            // addRecordToolStripMenuItem
            // 
            this.addRecordToolStripMenuItem.Name = "addRecordToolStripMenuItem";
            this.addRecordToolStripMenuItem.ShowShortcutKeys = false;
            this.addRecordToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.addRecordToolStripMenuItem.Text = "Add Record";
            this.addRecordToolStripMenuItem.Click += new System.EventHandler(this.addRecordToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.addToolStripMenuItem.Text = "Add Faculty";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // defaulterListToolStripMenuItem
            // 
            this.defaulterListToolStripMenuItem.Name = "defaulterListToolStripMenuItem";
            this.defaulterListToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.defaulterListToolStripMenuItem.Text = "Defaulter List";
            this.defaulterListToolStripMenuItem.Click += new System.EventHandler(this.defaulterListToolStripMenuItem_Click);
            // 
            // searchRecordToolStripMenuItem
            // 
            this.searchRecordToolStripMenuItem.Name = "searchRecordToolStripMenuItem";
            this.searchRecordToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.searchRecordToolStripMenuItem.Text = "Search Record";
            this.searchRecordToolStripMenuItem.Click += new System.EventHandler(this.searchRecordToolStripMenuItem_Click);
            // 
            // courToolStripMenuItem
            // 
            this.courToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCoursesToolStripMenuItem});
            this.courToolStripMenuItem.Name = "courToolStripMenuItem";
            this.courToolStripMenuItem.Size = new System.Drawing.Size(93, 30);
            this.courToolStripMenuItem.Text = "Courses";
            this.courToolStripMenuItem.Click += new System.EventHandler(this.courToolStripMenuItem_Click);
            // 
            // addCoursesToolStripMenuItem
            // 
            this.addCoursesToolStripMenuItem.Name = "addCoursesToolStripMenuItem";
            this.addCoursesToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.addCoursesToolStripMenuItem.Text = "Add Course";
            this.addCoursesToolStripMenuItem.Click += new System.EventHandler(this.addCoursesToolStripMenuItem_Click);
            // 
            // batchesToolStripMenuItem
            // 
            this.batchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBatchToolStripMenuItem,
            this.manageBatchToolStripMenuItem});
            this.batchesToolStripMenuItem.Name = "batchesToolStripMenuItem";
            this.batchesToolStripMenuItem.Size = new System.Drawing.Size(90, 30);
            this.batchesToolStripMenuItem.Text = "Batches";
            // 
            // addBatchToolStripMenuItem
            // 
            this.addBatchToolStripMenuItem.Name = "addBatchToolStripMenuItem";
            this.addBatchToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.addBatchToolStripMenuItem.Text = "Add Batch";
            this.addBatchToolStripMenuItem.Click += new System.EventHandler(this.addBatchToolStripMenuItem_Click);
            // 
            // manageBatchToolStripMenuItem
            // 
            this.manageBatchToolStripMenuItem.Name = "manageBatchToolStripMenuItem";
            this.manageBatchToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.manageBatchToolStripMenuItem.Text = "Manage Batch";
            this.manageBatchToolStripMenuItem.Click += new System.EventHandler(this.manageBatchToolStripMenuItem_Click);
            // 
            // collegeToolStripMenuItem
            // 
            this.collegeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollegeToolStripMenuItem});
            this.collegeToolStripMenuItem.Name = "collegeToolStripMenuItem";
            this.collegeToolStripMenuItem.Size = new System.Drawing.Size(89, 30);
            this.collegeToolStripMenuItem.Text = "College";
            // 
            // addCollegeToolStripMenuItem
            // 
            this.addCollegeToolStripMenuItem.Name = "addCollegeToolStripMenuItem";
            this.addCollegeToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.addCollegeToolStripMenuItem.Text = "Add College";
            this.addCollegeToolStripMenuItem.Click += new System.EventHandler(this.addCollegeToolStripMenuItem_Click);
            // 
            // cumapingToolStripMenuItem
            // 
            this.cumapingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cpToolStripMenuItem,
            this.bpToolStripMenuItem});
            this.cumapingToolStripMenuItem.Name = "cumapingToolStripMenuItem";
            this.cumapingToolStripMenuItem.Size = new System.Drawing.Size(81, 30);
            this.cumapingToolStripMenuItem.Text = "Assign";
            // 
            // cpToolStripMenuItem
            // 
            this.cpToolStripMenuItem.Name = "cpToolStripMenuItem";
            this.cpToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.cpToolStripMenuItem.Text = "Assign Course";
            this.cpToolStripMenuItem.Click += new System.EventHandler(this.cpToolStripMenuItem_Click);
            // 
            // bpToolStripMenuItem
            // 
            this.bpToolStripMenuItem.Name = "bpToolStripMenuItem";
            this.bpToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.bpToolStripMenuItem.Text = "Assign Batch";
            this.bpToolStripMenuItem.Click += new System.EventHandler(this.bpToolStripMenuItem_Click);
            // 
            // bmToolStripMenuItem
            // 
            this.bmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feeBatchToolStripMenuItem,
            this.feeCollectionToolStripMenuItem,
            this.expensesToolStripMenuItem,
            this.collectionDetailsToolStripMenuItem,
            this.viewExpensesToolStripMenuItem});
            this.bmToolStripMenuItem.Name = "bmToolStripMenuItem";
            this.bmToolStripMenuItem.Size = new System.Drawing.Size(53, 30);
            this.bmToolStripMenuItem.Text = "Fee";
            // 
            // feeBatchToolStripMenuItem
            // 
            this.feeBatchToolStripMenuItem.Name = "feeBatchToolStripMenuItem";
            this.feeBatchToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.feeBatchToolStripMenuItem.Text = "Expected Fee ";
            this.feeBatchToolStripMenuItem.Click += new System.EventHandler(this.feeBatchToolStripMenuItem_Click);
            // 
            // feeCollectionToolStripMenuItem
            // 
            this.feeCollectionToolStripMenuItem.Name = "feeCollectionToolStripMenuItem";
            this.feeCollectionToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.feeCollectionToolStripMenuItem.Text = "Fee collection";
            this.feeCollectionToolStripMenuItem.Click += new System.EventHandler(this.feeCollectionToolStripMenuItem_Click);
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.expensesToolStripMenuItem.Text = "Expenses";
            this.expensesToolStripMenuItem.Click += new System.EventHandler(this.expensesToolStripMenuItem_Click);
            // 
            // collectionDetailsToolStripMenuItem
            // 
            this.collectionDetailsToolStripMenuItem.Name = "collectionDetailsToolStripMenuItem";
            this.collectionDetailsToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.collectionDetailsToolStripMenuItem.Text = "Collection Details";
            this.collectionDetailsToolStripMenuItem.Click += new System.EventHandler(this.collectionDetailsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 191);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(658, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // viewExpensesToolStripMenuItem
            // 
            this.viewExpensesToolStripMenuItem.Name = "viewExpensesToolStripMenuItem";
            this.viewExpensesToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.viewExpensesToolStripMenuItem.Text = "View Expenses";
            this.viewExpensesToolStripMenuItem.Click += new System.EventHandler(this.viewExpensesToolStripMenuItem_Click);
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(658, 213);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collegeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollegeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cumapingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feeBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feeCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaulterListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewExpensesToolStripMenuItem;
    }
}