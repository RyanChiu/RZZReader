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
using System.Configuration;
using System.Security.Policy;
using System.Security.Cryptography;

namespace RZZReader
{
    public partial class FormMain : Form
    {
        private static string salt = "pleaseinputyourownsaltstringhere";
        
        public FormMain()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //ShowRSS("http://feed.cnblogs.com/blog/u/18638/rss");
            string urls = getConfigValue("urls");
            if (!String.IsNullOrEmpty(urls))
            {
                var arrUrl = urls.Split(',');
                var i = 0;
                foreach (var url in arrUrl)
                {
                    i++;
                    if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                    {
                        if (i != arrUrl.Length) listRSS(url, false);
                        else listRSS(url);
                    }
                }
            } else
            {
                notifyIcon.ShowBalloonTip(0, "Tips", "No RSS subscribed, please add one.", ToolTipIcon.Info);
            }
        }

        protected void listRSS(string rssURI, bool titlesOrNot = true)
        {
            SyndicationFeed sf = SyndicationFeed.Load(XmlReader.Create(rssURI));
            sf.BaseUri = new Uri(rssURI);
            Application.DoEvents();

            /*
            * insert rssURL and its name&content&everything into the treeview
            */
            TreeNode newNode = new TreeNode(sf.Title.Text);
            newNode.Tag = sf;
            treeViewRzz.Nodes.Add(newNode);

            if (titlesOrNot) listTitles(sf);
            else clearTitles();
        }

        protected void clearTitles()
        {
            listViewRzz.View = View.Details;
            listViewRzz.Items.Clear();
        }
        protected void listTitles(SyndicationFeed sf)
        {
            /*
             * insert contents including "title, link, date, summary and content" into listview
             */
            clearTitles();
            //listViewRzz.Sorting = SortOrder.Ascending;
            foreach (SyndicationItem it in sf.Items)
            {
                ListViewItem item = new ListViewItem(it.Title.Text);
                item.Tag = it;
                listViewRzz.Items.Add(item);

                Application.DoEvents();
            }
        }

        private void hideToNotifyIcon()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;
            this.Hide();
        }

        private void try2ShowRZZ()
        {
            notifyIcon.Visible = false;
            string cryptedPwd = getConfigValue("pwd");
            if (string.IsNullOrEmpty(cryptedPwd))
            {
                MessageBox.Show("It's your very 1st PIN setting, please remember it, FOR SURE.", "PIN");
            }

            FormAddSrc formPwd = new FormAddSrc();
            formPwd.setPwdMode();
            if (formPwd.ShowDialog() == DialogResult.OK)
            {
                notifyIcon.Visible = true;
                if (string.IsNullOrEmpty(cryptedPwd))
                {
                    setConfigValue("pwd", MD5Hash(formPwd.GetPwd() + salt));
                    notifyIcon.ShowBalloonTip(0, "Info", "PIN set, please keep going.", ToolTipIcon.Info);
                }
                else
                {
                    if (cryptedPwd == MD5Hash(formPwd.GetPwd() + salt))
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                        this.Show();
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(0, "Error", "Wrong PIN, please try again.", ToolTipIcon.Error);
                    }
                }
            }
            else
            {
                notifyIcon.Visible = true;
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

        public String getConfigValue(String key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];
        }

        private string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public bool setConfigValue(String key, String value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config != null)
                {
                    AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                    if (appSettings.Settings.AllKeys.Contains(key))
                    {
                        appSettings.Settings[key].Value = value;
                    }
                    else
                    {
                        appSettings.Settings.Add(key, value);
                    }
                    config.Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddSrc formAdd = new FormAddSrc();
            formAdd.StartPosition = FormStartPosition.CenterParent;
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                string url = formAdd.GetUrl();
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    try
                    {
                        listRSS(url);
                    } catch (Exception ex)
                    {
                        notifyIcon.ShowBalloonTip(0, "Error",
                            "Something went wrong, maybe the source just entered is not available.",
                            ToolTipIcon.Error);
                        return;
                    }
                    /*
                    * save rssURI into config file
                    */
                    string urls = getConfigValue("urls");
                    if (!String.IsNullOrEmpty(urls))
                    {
                        var arrUrls = urls.Split(',');
                        if (arrUrls.Contains(url))
                        {
                            notifyIcon.ShowBalloonTip(0, "Warning", "Duplicated resource, please try others.", ToolTipIcon.Warning);
                            return;
                        }
                        setConfigValue("urls", urls + "," + url);
                    }
                    else
                    {
                        setConfigValue("urls", url);
                    }
                }
                else
                {
                    notifyIcon.ShowBalloonTip(0, "Error", "Not a valid URL.", ToolTipIcon.Error);
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                hideToNotifyIcon();
                e.Cancel = true;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        private void treeViewRzz_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                // just do nothing
            } else if (me.Button == MouseButtons.Right)
            {
                /*
                 * pop up the menu let the item could be deleted or remaned or sth. like that.
                 */
                contextMenuStripTree.Show();
            }
        }

        private void treeViewRzz_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SyndicationFeed sf = (SyndicationFeed)e.Node.Tag;
            if (sf != null)
            {
                listTitles(sf);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyndicationFeed sf = (SyndicationFeed)treeViewRzz.SelectedNode.Tag;
            DialogResult dr =
                MessageBox.Show(
                    "Are you sure to delete the selected one below?\r\n************\r\n"
                        + sf.Title.Text + "\r\n"
                        + sf.BaseUri.OriginalString + "\r\n"
                        + "************", 
                    "Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                /*
                 * delete the selected RSS from tree view,
                 * and renew and sync the "settings"
                 * */
                treeViewRzz.Nodes.Remove(treeViewRzz.SelectedNode);
                string urls = getConfigValue("urls");
                if (!String.IsNullOrEmpty(urls))
                {
                    var arrUrl = urls.Split(',');
                    if (arrUrl.Contains(sf.BaseUri.OriginalString))
                    {
                        arrUrl = arrUrl.Except(new string[] { sf.BaseUri.OriginalString }).ToArray();
                        setConfigValue("urls", string.Join(",", arrUrl));
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(0, "Error", "No can do!", ToolTipIcon.Error);
                    }
                }
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try2ShowRZZ();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try2ShowRZZ();
        }
    }
}
