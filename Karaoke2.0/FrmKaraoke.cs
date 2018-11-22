using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karaoke2._0
{
    public partial class FrmKaraoke : Form
    {
        public FrmKaraoke(Cancion cancion)
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
            this._cancion = cancion;
            this.Text = cancion.Display;
        }
        private int _webBrowserScrollY = 1170; //370
        private int _webBrowser2ScrollY = 1970;
        private int _diferencia = 0;


        public Cancion _cancion { get; set; }
        private void FrmKaraoke_Load(object sender, EventArgs e)
        {
            //var uri = new Uri("file:///" + _cancion.FilePath);
            string html = File.ReadAllText(_cancion.FilePath);
            webBrowser.DocumentText = html;
            webBrowser2.DocumentText = html;
            //webBrowser.Navigate(uri);
            //webBrowser2.Navigate(uri);
            //webBrowser.Url = uri;
            //webBrowser2.Url = uri;
            _diferencia = _webBrowser2ScrollY - _webBrowserScrollY;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Document.Body.Style = "zoom:120%;";
            webBrowser.Document.Window.ScrollTo(700, _webBrowserScrollY);
            webBrowser.Document.Window.AttachEventHandler("onscroll", OnScrollWebBrowserEventHandler);
        }

        private void OnScrollWebBrowserEventHandler(object sender, EventArgs e)
        {
            int distanciaMoverWB2 = _webBrowser2ScrollY + webBrowser.Document.Window.Position.Y;
            webBrowser2.Document.Window.ScrollTo(0, distanciaMoverWB2);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Document.Body.Style = "zoom:120%;";
            webBrowser2.Document.Window.ScrollTo(0, _webBrowser2ScrollY);
            webBrowser2.Document.Window.AttachEventHandler("onscroll", OnScrollWebBrowser2EventHandler);
        }

        public void OnScrollWebBrowser2EventHandler(object sender, EventArgs e)
        {

        }
    }
}
