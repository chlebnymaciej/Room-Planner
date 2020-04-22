namespace ChlebnyWindowsFormsPWSG
{
    partial class RoomPlanner
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
            spareGP.Dispose();
            bitmap.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            // moze nie

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPlanner));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.furnitureAddGB = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chairsB = new System.Windows.Forms.Button();
            this.dbedB = new System.Windows.Forms.Button();
            this.sofaB = new System.Windows.Forms.Button();
            this.tableB = new System.Windows.Forms.Button();
            this.wallB = new System.Windows.Forms.Button();
            this.furnitureCreatedGB = new System.Windows.Forms.GroupBox();
            this.ListOfItems = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.furnitureAddGB.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.furnitureCreatedGB.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imagePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // imagePanel
            // 
            resources.ApplyResources(this.imagePanel, "imagePanel");
            this.imagePanel.Controls.Add(this.pictureBox1);
            this.imagePanel.Name = "imagePanel";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawImage);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageClickWithoutButtonSelected);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageMove);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.furnitureAddGB, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.furnitureCreatedGB, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // furnitureAddGB
            // 
            this.furnitureAddGB.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.furnitureAddGB, "furnitureAddGB");
            this.furnitureAddGB.Name = "furnitureAddGB";
            this.furnitureAddGB.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.chairsB);
            this.flowLayoutPanel1.Controls.Add(this.dbedB);
            this.flowLayoutPanel1.Controls.Add(this.sofaB);
            this.flowLayoutPanel1.Controls.Add(this.tableB);
            this.flowLayoutPanel1.Controls.Add(this.wallB);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // chairsB
            // 
            this.chairsB.BackgroundImage = global::ChlebnyWindowsFormsPWSG.Properties.Resources.coffee_table;
            resources.ApplyResources(this.chairsB, "chairsB");
            this.chairsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chairsB.Name = "chairsB";
            this.chairsB.UseVisualStyleBackColor = true;
            this.chairsB.Click += new System.EventHandler(this.chairsB_Click);
            // 
            // dbedB
            // 
            this.dbedB.BackgroundImage = global::ChlebnyWindowsFormsPWSG.Properties.Resources.double_bed;
            resources.ApplyResources(this.dbedB, "dbedB");
            this.dbedB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dbedB.Name = "dbedB";
            this.dbedB.UseVisualStyleBackColor = true;
            this.dbedB.Click += new System.EventHandler(this.dbedB_Click);
            // 
            // sofaB
            // 
            this.sofaB.BackgroundImage = global::ChlebnyWindowsFormsPWSG.Properties.Resources.sofa;
            resources.ApplyResources(this.sofaB, "sofaB");
            this.sofaB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sofaB.Name = "sofaB";
            this.sofaB.UseVisualStyleBackColor = true;
            this.sofaB.Click += new System.EventHandler(this.sofaB_Click);
            // 
            // tableB
            // 
            this.tableB.BackgroundImage = global::ChlebnyWindowsFormsPWSG.Properties.Resources.table;
            resources.ApplyResources(this.tableB, "tableB");
            this.tableB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableB.Name = "tableB";
            this.tableB.UseVisualStyleBackColor = true;
            this.tableB.Click += new System.EventHandler(this.tableB_Click);
            // 
            // wallB
            // 
            this.wallB.BackgroundImage = global::ChlebnyWindowsFormsPWSG.Properties.Resources.wall;
            resources.ApplyResources(this.wallB, "wallB");
            this.wallB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallB.Name = "wallB";
            this.wallB.UseVisualStyleBackColor = true;
            this.wallB.Click += new System.EventHandler(this.wallB_Click);
            // 
            // furnitureCreatedGB
            // 
            this.furnitureCreatedGB.Controls.Add(this.ListOfItems);
            resources.ApplyResources(this.furnitureCreatedGB, "furnitureCreatedGB");
            this.furnitureCreatedGB.Name = "furnitureCreatedGB";
            this.furnitureCreatedGB.TabStop = false;
            // 
            // ListOfItems
            // 
            resources.ApplyResources(this.ListOfItems, "ListOfItems");
            this.ListOfItems.FormattingEnabled = true;
            this.ListOfItems.Name = "ListOfItems";
            this.ListOfItems.SelectedIndexChanged += new System.EventHandler(this.ListOfItems_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.saveBlueprintToolStripMenuItem,
            this.openBlueprintToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            resources.ApplyResources(this.newBlueprintToolStripMenuItem, "newBlueprintToolStripMenuItem");
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polskiToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // polskiToolStripMenuItem
            // 
            this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
            resources.ApplyResources(this.polskiToolStripMenuItem, "polskiToolStripMenuItem");
            this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // saveBlueprintToolStripMenuItem
            // 
            this.saveBlueprintToolStripMenuItem.Name = "saveBlueprintToolStripMenuItem";
            resources.ApplyResources(this.saveBlueprintToolStripMenuItem, "saveBlueprintToolStripMenuItem");
            this.saveBlueprintToolStripMenuItem.Click += new System.EventHandler(this.saveBlueprintToolStripMenuItem_Click);
            // 
            // openBlueprintToolStripMenuItem
            // 
            this.openBlueprintToolStripMenuItem.Name = "openBlueprintToolStripMenuItem";
            resources.ApplyResources(this.openBlueprintToolStripMenuItem, "openBlueprintToolStripMenuItem");
            this.openBlueprintToolStripMenuItem.Click += new System.EventHandler(this.openBlueprintToolStripMenuItem_Click);
            // 
            // RoomPlanner
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RoomPlanner";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RoomPlanner_KeyUp);
            this.Resize += new System.EventHandler(this.RoomPlanner_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.furnitureAddGB.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.furnitureCreatedGB.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox furnitureAddGB;
        private System.Windows.Forms.GroupBox furnitureCreatedGB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button chairsB;
        private System.Windows.Forms.Button dbedB;
        private System.Windows.Forms.Button sofaB;
        private System.Windows.Forms.Button tableB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox ListOfItems;
        private System.Windows.Forms.FlowLayoutPanel imagePanel;
        private System.Windows.Forms.Button wallB;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBlueprintToolStripMenuItem;
    }
}

