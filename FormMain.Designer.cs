namespace RZZReader
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainerFeeds = new System.Windows.Forms.SplitContainer();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.treeViewRzz = new System.Windows.Forms.TreeView();
            this.contextMenuStripTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerFees = new System.Windows.Forms.SplitContainer();
            this.listViewRzz = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.webBrowserRzz = new System.Windows.Forms.WebBrowser();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeeds)).BeginInit();
            this.splitContainerFeeds.Panel1.SuspendLayout();
            this.splitContainerFeeds.Panel2.SuspendLayout();
            this.splitContainerFeeds.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStripTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFees)).BeginInit();
            this.splitContainerFees.Panel1.SuspendLayout();
            this.splitContainerFees.Panel2.SuspendLayout();
            this.splitContainerFees.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerFeeds
            // 
            this.splitContainerFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFeeds.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFeeds.Name = "splitContainerFeeds";
            // 
            // splitContainerFeeds.Panel1
            // 
            this.splitContainerFeeds.Panel1.Controls.Add(this.toolStripMain);
            this.splitContainerFeeds.Panel1.Controls.Add(this.treeViewRzz);
            // 
            // splitContainerFeeds.Panel2
            // 
            this.splitContainerFeeds.Panel2.Controls.Add(this.splitContainerFees);
            this.splitContainerFeeds.Size = new System.Drawing.Size(800, 450);
            this.splitContainerFeeds.SplitterDistance = 179;
            this.splitContainerFeeds.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAdd});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(179, 27);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripBtnAdd
            // 
            this.toolStripBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAdd.Image")));
            this.toolStripBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdd.Name = "toolStripBtnAdd";
            this.toolStripBtnAdd.Size = new System.Drawing.Size(24, 24);
            this.toolStripBtnAdd.Text = "toolStripButtonAdd";
            this.toolStripBtnAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // treeViewRzz
            // 
            this.treeViewRzz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewRzz.ContextMenuStrip = this.contextMenuStripTree;
            this.treeViewRzz.Location = new System.Drawing.Point(0, 30);
            this.treeViewRzz.Name = "treeViewRzz";
            this.treeViewRzz.Size = new System.Drawing.Size(179, 888);
            this.treeViewRzz.TabIndex = 1;
            this.treeViewRzz.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRzz_AfterSelect);
            this.treeViewRzz.Click += new System.EventHandler(this.treeViewRzz_Click);
            // 
            // contextMenuStripTree
            // 
            this.contextMenuStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStripTree.Name = "contextMenuStripTree";
            this.contextMenuStripTree.Size = new System.Drawing.Size(114, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // splitContainerFees
            // 
            this.splitContainerFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFees.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFees.Name = "splitContainerFees";
            // 
            // splitContainerFees.Panel1
            // 
            this.splitContainerFees.Panel1.Controls.Add(this.listViewRzz);
            // 
            // splitContainerFees.Panel2
            // 
            this.splitContainerFees.Panel2.Controls.Add(this.webBrowserRzz);
            this.splitContainerFees.Size = new System.Drawing.Size(617, 450);
            this.splitContainerFees.SplitterDistance = 164;
            this.splitContainerFees.TabIndex = 1;
            // 
            // listViewRzz
            // 
            this.listViewRzz.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle});
            this.listViewRzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRzz.HideSelection = false;
            this.listViewRzz.Location = new System.Drawing.Point(0, 0);
            this.listViewRzz.Name = "listViewRzz";
            this.listViewRzz.Size = new System.Drawing.Size(164, 450);
            this.listViewRzz.TabIndex = 0;
            this.listViewRzz.UseCompatibleStateImageBehavior = false;
            this.listViewRzz.Click += new System.EventHandler(this.listViewRzz_Click);
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 320;
            // 
            // webBrowserRzz
            // 
            this.webBrowserRzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserRzz.Location = new System.Drawing.Point(0, 0);
            this.webBrowserRzz.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserRzz.Name = "webBrowserRzz";
            this.webBrowserRzz.Size = new System.Drawing.Size(449, 450);
            this.webBrowserRzz.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "RZZ";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItemExit});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(109, 48);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerFeeds);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "RZZReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.splitContainerFeeds.Panel1.ResumeLayout(false);
            this.splitContainerFeeds.Panel1.PerformLayout();
            this.splitContainerFeeds.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeeds)).EndInit();
            this.splitContainerFeeds.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStripTree.ResumeLayout(false);
            this.splitContainerFees.Panel1.ResumeLayout(false);
            this.splitContainerFees.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFees)).EndInit();
            this.splitContainerFees.ResumeLayout(false);
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFeeds;
        private System.Windows.Forms.TreeView treeViewRzz;
        private System.Windows.Forms.SplitContainer splitContainerFees;
        private System.Windows.Forms.ListView listViewRzz;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdd;
        private System.Windows.Forms.WebBrowser webBrowserRzz;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTree;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

