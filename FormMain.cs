using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RZZReader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            ShowRSS("http://feed.cnblogs.com/blog/u/18638/rss");
        }

        protected void ShowRSS(string rssURI)
        {
            SyndicationFeed sf = SyndicationFeed.Load(XmlReader.Create(rssURI));

            webBrowserRzz.Navigate("about:blank");
            while (webBrowserRzz.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            string html = "title:" + sf.Title.Text + "\r\n";
            if (sf.Links.Count > 0)
                html += "Link:" + sf.Links[0].Uri.ToString() + "\r\n";
            if (sf.Authors.Count > 0 && !string.IsNullOrEmpty(sf.Authors[0].Uri))
                html += "Link:" + sf.Authors[0].Uri.ToString() + "\r\n";
            html += "pubDate:" + sf.LastUpdatedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";

            foreach (SyndicationItem it in sf.Items)
            {
                html += "\r\n-----------------------------------------------------\r\n";
                html += "title:" + it.Title.Text + "\r\n";
                if (it.Links.Count > 0)
                    html += "Link:" + it.Links[0].Uri.ToString() + "\r\n";
                html += "PubDate:" + it.PublishDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                if (it.Summary != null)
                    html += "Summary:" + it.Summary.Text + "\r\n";
                if (it.Content != null)
                    html += "Content:" + ((TextSyndicationContent)it.Content).Text + "\r\n";
                Application.DoEvents();
            }
            webBrowserRzz.Document.Write(html);

            /*
             * insert rssURL and its name into the treeview
             */
            TreeNode newNode = new TreeNode(sf.Title.Text);
            newNode.Tag = sf;
            treeViewRzz.Nodes.Add(newNode);

            /*
             * insert comtents including "title, link, date, summary and content" into listview
             */
            listViewRzz.View = View.Details;
            listViewRzz.Items.Clear();
            listViewRzz.Sorting = SortOrder.Ascending;
            listViewRzz.Columns.Add("RZZ", -2, HorizontalAlignment.Left);
            foreach (SyndicationItem it in sf.Items)
            {
                ListViewItem item = new ListViewItem(it.Title.Text);
                item.Tag = it;
                listViewRzz.Items.Add(item);

                Application.DoEvents();
            }
        }

        string syndicationItemToString(SyndicationItem it)
        {
            string text = "";
            text += "<h1>" + it.Title.Text + "</h1>";
            text += it.PublishDate.ToString("yyyy-MM-dd HH:mm:ss") + "<br><hr>";
            if (it.Links.Count > 0)
                text += "<a href=\"" + it.Links[0].Uri.ToString() + "\">" + it.Links[0].Uri.ToString() + "</a><hr>";
            if (it.Summary != null)
                text += it.Summary.Text + "<hr>";
            if (it.Content != null)
                text += ((TextSyndicationContent)it.Content).Text;
            return text;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddSrc formAdd = new FormAddSrc();
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                string url = formAdd.GetUrl();
                bool isUrlValid = Uri.IsWellFormedUriString(url, UriKind.Absolute);
                if (isUrlValid)
                {
                    ShowRSS(url);
                }
                else
                {
                    MessageBox.Show("Not a valid URL.");
                }
            }
            formAdd.Close();
        }

        private void listViewRzz_Click(object sender, EventArgs e)
        {
            if (listViewRzz.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewRzz.SelectedItems[0];
                SyndicationItem it = item.Tag as SyndicationItem;

                webBrowserRzz.Navigate("about:blank");
                while (webBrowserRzz.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                webBrowserRzz.Document.Write(syndicationItemToString(it));
            }
            else return;
        }
    }
}
