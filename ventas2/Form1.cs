using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ventas2
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();

        }

        private void ventas_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Productos.txt"))
            {
                StreamWriter swProductos = new StreamWriter("Productos.txt");
                swProductos.WriteLine("");
                swProductos.Close();
            }
            else
            {
                TextReader lector = new StreamReader("Productos.txt");
                string[] leer = File.ReadAllLines("Productos.txt");
                foreach (string item in leer)
                {
                    lstProductos.Items.Add(item);
                }
                lector.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtProductos.Text != "")
                lstProductos.Items.Add(txtProductos.Text);
                txtProductos.Text = "";
            nvalista();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstProductos.SelectedIndex != -1)
                lstProductos.Items.RemoveAt(lstProductos.SelectedIndex);
            txtProductos.Text = "";
            nvalista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                if (txtProductos.Text != "" & lstProductos.SelectedIndex != -1)
                {
                    lstProductos.Items.Insert(lstProductos.SelectedIndex, txtProductos.Text);
                    lstProductos.Items.RemoveAt(lstProductos.SelectedIndex);
                    btnEditar.Text = "Editar";
                    txtProductos.Text = "";
                    nvalista();

                }
                else
                {
                    btnEditar.Text = "Aceptar";
                    txtProductos.Text = lstProductos.SelectedItem.ToString();
                }
               
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void nvalista()
        {
            TextWriter nvoarchivo = new StreamWriter("Productos.txt");
            foreach (object lista in lstProductos.Items)
                nvoarchivo.WriteLine(lista);
            nvoarchivo.Close();
        }
    }
}
