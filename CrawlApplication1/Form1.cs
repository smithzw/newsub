using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using mshtml;
using System.Reflection;
using System.Collections;

namespace CrawlApplication1
{
   public partial class Form1 : Form
    {
       private int n = 0;
       private bool bFirst = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = "function sayHello() { var objs = new Array(4);  alert(__HOST__.img_prefix); var b = arr_pages.join(\"|\"); return b; }";//var b = objs.join(\"-\");
            //IHTMLScriptElement el;

            head.AppendChild(scriptEl);
            ////webBrowser1.Document.InvokeScript("sayHello");
            ////string jCode = "alert(\"HelloHelloHelloHello\");";
            //// or any combination of your JavaScript commands
            //// (including function calls, variables... etc)
            //IHTMLDocument2 aa;
            //// WebBrowser webBrowser1 is what you are using for your web browser
            ////webBrowser1.Document.InvokeScript("eval", new object[] { jCode });
            //object[] objs = new object[4];
            //object obj = webBrowser1.Document.InvokeScript("jsAlert", new String[] { "info1", "info2" });
            //MessageBox.Show(objs.ToString());
            IHTMLDocument2 vDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;
            IHTMLWindow2 vWindow = vDocument.parentWindow;
            Type vWindowType = vWindow.GetType();
            ArrayList alist = new ArrayList();
            string[] strs = new string[4];
            //object xpt = vWindowType.InvokeMember("_xpt", BindingFlags.GetProperty, null, vWindow, new object[] { });

            object getarr =  webBrowser1.Document.InvokeScript("sayHello", new object[] { });
            MessageBox.Show(getarr.ToString());
        }
        //public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser.DocumentTitle 属性值更改时发生。
        //public event EventHandler DocumentTitleChanged;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser 控件导航到或离开使用了加密的网站时发生。
        //public event EventHandler EncryptionLevelChanged;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser 控件下载文件时发生。
        //public event EventHandler FileDownload;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser 控件导航到新文档并开始加载该文档时发生。
        //public event WebBrowserNavigatedEventHandler Navigated;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser 控件导航到新文档之前发生。
        //public event WebBrowserNavigatingEventHandler Navigating;
        ////
        //// 摘要:
        ////     在浏览器新窗口打开之前发生。
        //public event CancelEventHandler NewWindow;
        ////
        //// 摘要:
        ////     当 System.Windows.Forms.WebBrowser.Padding 属性的值更改时发生。
        //public event EventHandler PaddingChanged;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser 控件已更新有关要导航到的文档的下载进度的信息时发生。
        //public event WebBrowserProgressChangedEventHandler ProgressChanged;
        ////
        //// 摘要:
        ////     在 System.Windows.Forms.WebBrowser.StatusText 属性值更改时发生。
        //public event EventHandler StatusTextChanged;

        private void Form1_Load(object sender, EventArgs e)
        {
            //FileInfo file = new FileInfo("index.html");
            //FileInfo file = new FileInfo("http://www.dmzj.com/shengdoushi/15177.shtml");
            //webBrowser1.Url = new Uri(file.FullName);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            //     在 System.Windows.Forms.WebBrowser.DocumentTitle 属性值更改时发生。
            webBrowser1.DocumentTitleChanged += new EventHandler(webBrowser1_DocumentTitleChanged);
            //     在 System.Windows.Forms.WebBrowser 控件导航到或离开使用了加密的网站时发生。
            webBrowser1.EncryptionLevelChanged += new EventHandler(webBrowser1_EncryptionLevelChanged);
            //     在 System.Windows.Forms.WebBrowser 控件下载文件时发生。
            webBrowser1.FileDownload += new EventHandler(webBrowser1_FileDownload);
                 //在 System.Windows.Forms.WebBrowser 控件导航到新文档并开始加载该文档时发生。
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            //     在 System.Windows.Forms.WebBrowser 控件导航到新文档之前发生。
            webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
            //     在浏览器新窗口打开之前发生。
            webBrowser1.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
            //     在 System.Windows.Forms.WebBrowser.StatusText 属性值更改时发生。
            webBrowser1.StatusTextChanged +=new EventHandler(webBrowser1_StatusTextChanged);
            //     当 System.Windows.Forms.WebBrowser.Padding 属性的值更改时发生。
            webBrowser1.ProgressChanged +=new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);

            webBrowser1.ParentChanged += new EventHandler(webBrowser1_ParentChanged);
            webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(webBrowser1_PreviewKeyDown);
            //     在 System.Windows.Forms.WebBrowser 控件已更新有关要导航到的文档的下载进度的信息时发生。
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);

            webBrowser1.Navigate("http://www.dmzj.com/shengdoushi/15177.shtml");
            //webBrowser1.ObjectForScripting = this;
        }
        
        void  webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("StatusTextChanged");
        }
        void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            //MessageBox.Show("FileDownload");
        }
        void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //MessageBox.Show("ProgressChanged");
        }
        void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //MessageBox.Show("PreviewKeyDown");
        }
        void webBrowser1_ParentChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("ParentChanged");
        }
        void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("NewWindow");
        }
        void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //MessageBox.Show("Navigating");
        }
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //MessageBox.Show("Navigated");
        }
        void webBrowser1_EncryptionLevelChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("EncryptionLevelChanged");
        }
        void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("DocumentTitleChanged");
        }
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
            if (head == null) return;
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            if (scriptEl == null) return;
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            if (element == null) return;
            element.text = "function sayHello() { var objs = new Array(4);  alert(__HOST__.img_prefix); var b = arr_pages.join(\"|\"); return b; }";//var b = objs.join(\"-\");

            HtmlElement e1 = head.AppendChild(scriptEl);
            
            if (e1 == null) return;
            //IHTMLDocument2 vDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;
            //IHTMLWindow2 vWindow = vDocument.parentWindow;
            //Type vWindowType = vWindow.GetType();
            //ArrayList alist = new ArrayList();
            ////string[] strs = new string[4];
            
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                if (bFirst)
                {
                    bFirst = false;
                    return;
                }
                //n++;
                object getarr = webBrowser1.Document.InvokeScript("sayHello", new object[] { });
                MessageBox.Show(getarr.ToString());
            }
            //if (n < 2) return;
            //n = 0;

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.ResetText();
            webBrowser1.Navigate(UrlTextBox.Text.Trim());
        }
    }
}
