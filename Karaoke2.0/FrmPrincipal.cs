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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();            
        }

        string path = $"{Environment.CurrentDirectory}\\..\\..\\canciones.txt";

        List<Cancion> lstCanciones = new List<Cancion>();

        private void CargarCanciones()
        {
            if (File.Exists(path))
            {
                var cancionesTxt = File.ReadAllLines(path);
                lstCanciones.Clear();
                for (int i = 0; i < cancionesTxt.Length; i++)
                {
                    lstCanciones.Add(new Cancion(i, cancionesTxt[i]));
                }                

                var cancionesOrdenadas = lstCanciones.OrderBy(z => z.Artista).ThenBy(z => z.Tema).ToList();
                lstboxTemas.DisplayMember = "Display";
                lstboxTemas.ValueMember = "Id";
                lstboxTemas.DataSource = cancionesOrdenadas;
                //foreach (var cancion in cancionesOrdenadas)
                //{
                //    lstboxTemas.Items.Add();
                //}
            }
        }

        private void lstTemas_DoubleClick(object sender, EventArgs e)
        {
            if (lstboxTemas.SelectedItem == null)
                return;
            var selectedItem = lstboxTemas.SelectedItem;
            var frmKaraoke = new FrmKaraoke((Cancion)selectedItem);
            if (frmKaraoke.ShowDialog() == DialogResult.OK)
            {
                CargarCanciones();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Cursor Files|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lstboxTemas.DataSource = new List<Cancion>();                
                path = ofd.FileName;
                CargarCanciones();
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarCanciones();
        }
    }
}
