using CefSharp;

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
            this.editSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerFeed = new System.Windows.Forms.SplitContainer();
            this.listViewRzz = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.csWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.toolStripWeb = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSHTitles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCollectImgLinks = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxImgs = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerFeeds = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeeds)).BeginInit();
            this.splitContainerFeeds.Panel1.SuspendLayout();
            this.splitContainerFeeds.Panel2.SuspendLayout();
            this.splitContainerFeeds.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStripTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeed)).BeginInit();
            this.splitContainerFeed.Panel1.SuspendLayout();
            this.splitContainerFeed.Panel2.SuspendLayout();
            this.splitContainerFeed.SuspendLayout();
            this.toolStripWeb.SuspendLayout();
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
            this.splitContainerFeeds.Panel2.Controls.Add(this.splitContainerFeed);
            this.splitContainerFeeds.Size = new System.Drawing.Size(640, 359);
            this.splitContainerFeeds.SplitterDistance = 142;
            this.splitContainerFeeds.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAdd});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(142, 27);
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
            this.toolStripBtnAdd.Text = "add your RSS source";
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
            this.treeViewRzz.Size = new System.Drawing.Size(141, 329);
            this.treeViewRzz.TabIndex = 1;
            this.treeViewRzz.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRzz_AfterSelect);
            this.treeViewRzz.Click += new System.EventHandler(this.treeViewRzz_Click);
            // 
            // contextMenuStripTree
            // 
            this.contextMenuStripTree.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.editSourceToolStripMenuItem});
            this.contextMenuStripTree.Name = "contextMenuStripTree";
            this.contextMenuStripTree.Size = new System.Drawing.Size(143, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editSourceToolStripMenuItem
            // 
            this.editSourceToolStripMenuItem.Name = "editSourceToolStripMenuItem";
            this.editSourceToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.editSourceToolStripMenuItem.Text = "Edit Source";
            this.editSourceToolStripMenuItem.Click += new System.EventHandler(this.editSourceToolStripMenuItem_Click);
            // 
            // splitContainerFeed
            // 
            this.splitContainerFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFeed.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFeed.Name = "splitContainerFeed";
            // 
            // splitContainerFeed.Panel1
            // 
            this.splitContainerFeed.Panel1.Controls.Add(this.listViewRzz);
            // 
            // splitContainerFeed.Panel2
            // 
            this.splitContainerFeed.Panel2.Controls.Add(this.csWebBrowser);
            this.splitContainerFeed.Panel2.Controls.Add(this.toolStripWeb);
            this.splitContainerFeed.Size = new System.Drawing.Size(494, 359);
            this.splitContainerFeed.SplitterDistance = 131;
            this.splitContainerFeed.TabIndex = 1;
            // 
            // listViewRzz
            // 
            this.listViewRzz.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle});
            this.listViewRzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRzz.HideSelection = false;
            this.listViewRzz.Location = new System.Drawing.Point(0, 0);
            this.listViewRzz.Name = "listViewRzz";
            this.listViewRzz.Size = new System.Drawing.Size(131, 359);
            this.listViewRzz.TabIndex = 0;
            this.listViewRzz.UseCompatibleStateImageBehavior = false;
            this.listViewRzz.Click += new System.EventHandler(this.listViewRzz_Click);
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 320;
            // 
            // csWebBrowser
            // 
            this.csWebBrowser.ActivateBrowserOnCreation = false;
            this.csWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csWebBrowser.Location = new System.Drawing.Point(0, 27);
            this.csWebBrowser.Name = "csWebBrowser";
            this.csWebBrowser.Size = new System.Drawing.Size(359, 332);
            this.csWebBrowser.TabIndex = 2;
            // 
            // toolStripWeb
            // 
            this.toolStripWeb.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripWeb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSHTitles,
            this.toolStripSeparator2,
            this.toolStripButtonCollectImgLinks,
            this.toolStripTextBoxImgs,
            this.toolStripSeparator1});
            this.toolStripWeb.Location = new System.Drawing.Point(0, 0);
            this.toolStripWeb.Name = "toolStripWeb";
            this.toolStripWeb.Size = new System.Drawing.Size(359, 27);
            this.toolStripWeb.TabIndex = 1;
            this.toolStripWeb.Text = "toolStrip1";
            // 
            // toolStripButtonSHTitles
            // 
            this.toolStripButtonSHTitles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSHTitles.Image = global::RZZReader.Properties.Resources._2left;
            this.toolStripButtonSHTitles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSHTitles.Name = "toolStripButtonSHTitles";
            this.toolStripButtonSHTitles.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSHTitles.Text = "Show/Hide Feeds";
            this.toolStripButtonSHTitles.Click += new System.EventHandler(this.toolStripButtonSHTitles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonCollectImgLinks
            // 
            this.toolStripButtonCollectImgLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCollectImgLinks.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCollectImgLinks.Image")));
            this.toolStripButtonCollectImgLinks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCollectImgLinks.Name = "toolStripButtonCollectImgLinks";
            this.toolStripButtonCollectImgLinks.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCollectImgLinks.Text = "Collect all the image links";
            this.toolStripButtonCollectImgLinks.Click += new System.EventHandler(this.toolStripButtonCollectImgLinks_Click);
            // 
            // toolStripTextBoxImgs
            // 
            this.toolStripTextBoxImgs.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBoxImgs.Name = "toolStripTextBoxImgs";
            this.toolStripTextBoxImgs.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripTextBoxImgs.ReadOnly = true;
            this.toolStripTextBoxImgs.Size = new System.Drawing.Size(75, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            this.contextMenuStripTray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItemExit});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(109, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // bgWorkerFeeds
            // 
            this.bgWorkerFeeds.WorkerReportsProgress = true;
            this.bgWorkerFeeds.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerFeeds_DoWork);
            this.bgWorkerFeeds.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerFeeds_ProgressChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 359);
            this.Controls.Add(this.splitContainerFeeds);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "RZZReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.splitContainerFeeds.Panel1.ResumeLayout(false);
            this.splitContainerFeeds.Panel1.PerformLayout();
            this.splitContainerFeeds.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeeds)).EndInit();
            this.splitContainerFeeds.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStripTree.ResumeLayout(false);
            this.splitContainerFeed.Panel1.ResumeLayout(false);
            this.splitContainerFeed.Panel2.ResumeLayout(false);
            this.splitContainerFeed.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFeed)).EndInit();
            this.splitContainerFeed.ResumeLayout(false);
            this.toolStripWeb.ResumeLayout(false);
            this.toolStripWeb.PerformLayout();
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFeeds;
        private System.Windows.Forms.TreeView treeViewRzz;
        private System.Windows.Forms.SplitContainer splitContainerFeed;
        private System.Windows.Forms.ListView listViewRzz;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdd;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTree;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripWeb;
        private System.Windows.Forms.ToolStripButton toolStripButtonCollectImgLinks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxImgs;
        private System.ComponentModel.BackgroundWorker bgWorkerFeeds;
        private System.Windows.Forms.ToolStripMenuItem editSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSHTitles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private CefSharp.WinForms.ChromiumWebBrowser csWebBrowser;
    }
}

