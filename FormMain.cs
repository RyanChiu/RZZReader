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
using System.Text.RegularExpressions;
using System.Web;

namespace RZZReader
{
    public partial class FormMain : Form
    {
        private static string salt = "pleaseinputyourownsaltstringhere";
        private FormLoading formLoading = null;
        
        public FormMain()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        protected SyndicationFeed loadRSS(string rssURI)
        {
            try
            {
                SyndicationFeed sf = SyndicationFeed.Load(XmlReader.Create(rssURI));
                sf.BaseUri = new Uri(rssURI);
                return sf;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        protected void listRSS(SyndicationFeed sf, string folder = "default", 
            bool showTitles = true, bool onlyReloaded = false)
        {
            if (sf == null) return;

            /*
            this.ShowInTaskbar = true;
            this.notifyIcon.Visible = false;
            */

            if (folder == null) folder = "default";

            TreeNode folderNode;
            if (treeViewRzz.Nodes.Count > 0)
            {
                int i = 0;
                for (i = 0; i < treeViewRzz.Nodes.Count; i++)
                {
                    if (treeViewRzz.Nodes[i].Text == folder)
                    {
                        break;
                    }
                }
                if (i == treeViewRzz.Nodes.Count)
                {
                    folderNode = treeViewRzz.Nodes.Add(folder);
                } else
                {
                    folderNode = treeViewRzz.Nodes[i];
                }
            } else
            {
                folderNode = treeViewRzz.Nodes.Add(folder);
            }

            if (onlyReloaded)
            {
                treeViewRzz.SelectedNode.Text = sf.Title.Text;
                treeViewRzz.SelectedNode.Tag = sf;
            } else
            {
                /*
                * insert rssURL and its name&content&everything into the treeview
                */
                TreeNode newNode = new TreeNode(sf.Title.Text);
                newNode.Tag = sf;
                folderNode.Nodes.Add(newNode);
            }

            if (showTitles) listTitles(sf);
            else clearTitles();

            /*
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;
            */
        }

        protected void clearTitles()
        {
            listViewRzz.Items.Clear();
        }
        protected void listTitles(SyndicationFeed sf)
        {
            /*
             * insert contents including "title, link, date, summary and content" into listview
             */
            clearTitles();
            listViewRzz.Columns[0].Text = sf.Title.Text;
            //listViewRzz.Sorting = SortOrder.Ascending;
            foreach (SyndicationItem it in sf.Items)
            {
                ListViewItem item = new ListViewItem(it.Title.Text);
                item.Tag = it;
                listViewRzz.Items.Add(item);

                //Application.DoEvents();
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

            FormInput formPwd = new FormInput();
            formPwd.setPwdMode();
            if (formPwd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(cryptedPwd))
                {
                    setConfigValue("pwd", MD5Hash(formPwd.GetPwd() + salt));
                    notifyIcon.Visible = true;
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

        List<string> getImageLinks(string htmlContent)
        {
            List<string> imageLinks = new List<string>();

            string pattern = @"<img.*?src=""(.*?)"".*?>";
            MatchCollection matches = Regex.Matches(htmlContent, pattern);

            foreach (Match match in matches)
            {
                string imageUrl = match.Groups[1].Value;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    imageLinks.Add(imageUrl);
                }
            }

            return imageLinks;
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
            FormInput formAdd = new FormInput();
            formAdd.StartPosition = FormStartPosition.CenterParent;
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                string url = formAdd.GetUrl();
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    SyndicationFeed sf = loadRSS(url);
                    notifyIcon.Visible = true;
                    if (sf != null)
                    {
                        listRSS(sf);
                    } else
                    {
                        notifyIcon.ShowBalloonTip(0, "Error",
                            "Something went wrong, maybe the source just entered is not available.",
                            ToolTipIcon.Error);
                        notifyIcon.Visible = false;
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
                            notifyIcon.ShowBalloonTip(0, "Warning", 
                                "Duplicated resource, please try others.", 
                                ToolTipIcon.Warning);
                            notifyIcon.Visible = false;
                            return;
                        }
                        setConfigValue("urls", urls + "," + url);
                    }
                    else
                    {
                        setConfigValue("urls", url);
                    }
                    notifyIcon.Visible = false;
                }
                else
                {
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(0, "Error", "Not a valid URL.", ToolTipIcon.Error);
                    notifyIcon.Visible = false;
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
                        notifyIcon.Visible = true;
                        notifyIcon.ShowBalloonTip(0, "Error", "No can do!", ToolTipIcon.Error);
                        notifyIcon.Visible = false;
                    }
                }
            }
        }

        private void editSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyndicationFeed sf = (SyndicationFeed)treeViewRzz.SelectedNode.Tag;
            string oldUrl = sf.BaseUri.OriginalString;
            FormInput formIpt = new FormInput();
            formIpt.Text = "Edit the source";
            formIpt.StartPosition = FormStartPosition.CenterParent;
            formIpt.SetUrl(oldUrl);
            DialogResult dr = formIpt.ShowDialog();
            string url = formIpt.GetUrl();
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                if (dr == DialogResult.OK)
                {
                    //MessageBox.Show("should do the editing");
                    //use the new url to load the RSS
                    sf = loadRSS(url);
                    notifyIcon.Visible = true;
                    //list the RSS into the tree and list view, but not content browser
                    if (sf != null)
                    {
                        listRSS(sf, null, true, true);
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(0, "Error",
                            "Something went wrong, maybe the source just entered is not available.",
                            ToolTipIcon.Error);
                        notifyIcon.Visible = false;
                        return;
                    }
                    //save it to the config file
                    string urls = getConfigValue("urls");
                    if (!String.IsNullOrEmpty(urls))
                    {
                        List<string> list = urls.Split(',').ToList();
                        int idx = list.IndexOf(oldUrl);
                        list.RemoveAt(idx);
                        urls = String.Join(",", list.ToArray());
                        setConfigValue("urls", urls + "," + url);
                    }
                    else
                    {
                        setConfigValue("urls", url);
                    }
                }
            } else
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(0, "Error", "Not a valid URL.", ToolTipIcon.Error);
                notifyIcon.Visible = false;
            }
            formIpt.Close();
            formIpt.Dispose();
        }


        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try2ShowRZZ();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try2ShowRZZ();
        }

        private void toolStripButtonCollectImgLinks_Click(object sender, EventArgs e)
        {
            string htmlContent = webBrowserRzz.DocumentText;
            List<string> links = getImageLinks(htmlContent);
            if (links.Count > 0)
            {
                string ss = "";
                foreach (string link in links)
                {
                    ss += link + "\r\n";
                }
                toolStripTextBoxImgs.Text = ss;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(0, "Info", "Image links collected.", ToolTipIcon.Info);
                notifyIcon.Visible = false;
            } else
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(0, "Tips", "Seems that there are no images.", ToolTipIcon.Info);
                notifyIcon.Visible = false;
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) //Ctrl + R
            {
                try
                {
                    hideToNotifyIcon();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listViewRzz.View = View.Details;
            notifyIcon.Visible = false;
            string urls = getConfigValue("urls");
            if (!String.IsNullOrEmpty(urls))
            {
                var arrUrl = urls.Split(',');
                formLoading = new FormLoading();
                formLoading.Tag = notifyIcon;
                formLoading.setBar(arrUrl.Length);
                formLoading.setProgress(0);
                formLoading.Show();
                backgroundWorker.RunWorkerAsync(arrUrl);
            } else
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(0, "Tips", "No RSS subscribed, please add one.", ToolTipIcon.Info);
            }
        }

        class RZZs
        {
            public int cur = 0;
            public string[] urls = null;
            public List<SyndicationFeed> feeds = new List<SyndicationFeed>();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            RZZs rZZs = new RZZs();
            var arrUrl = (string[])e.Argument;
            rZZs.urls = arrUrl;
            foreach (var url in arrUrl)
            {
                SyndicationFeed sf = loadRSS(url);
                rZZs.feeds.Add(sf);
                rZZs.cur++;
                bw.ReportProgress(rZZs.cur, rZZs);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RZZs rZZs = e.UserState as RZZs;
            SyndicationFeed sf = rZZs.feeds[rZZs.cur - 1];
            if (sf != null)
            {
                formLoading.setProgress(rZZs.cur);
                if (rZZs.cur != rZZs.urls.Length)
                {
                    listRSS(sf, null, false);
                }
                else
                {
                    listRSS(sf);
                    formLoading.Close();
                    formLoading.Dispose();
                }
            }
            else
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(0, "Error",
                    String.Format("Something went wrong, maybe the source '{0}' is not available.", (sf == null ? "" : sf.BaseUri.OriginalString)),
                    ToolTipIcon.Error);
                notifyIcon.Visible = false;
            }
        }

        private void toolStripButtonSHTitles_Click(object sender, EventArgs e)
        {
            splitContainerFeed.Panel1Collapsed = !splitContainerFeed.Panel1Collapsed;

            if (splitContainerFeed.Panel1Collapsed)
            {
                toolStripButtonSHTitles.Image = global::RZZReader.Properties.Resources._2right;
            } else
            {
                toolStripButtonSHTitles.Image = global::RZZReader.Properties.Resources._2left;
            }
        }
    }
}
