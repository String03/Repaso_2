using Repaso_2.BLL;
using Repaso_2.DAL;
using Repaso_2.EE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_2
{
    public partial class Form1 : Form
    {
        private GeneroBLL generoBLL;

        public Form1()
        {
            InitializeComponent();
            generoBLL = new GeneroBLL(new Repository<Genero>());
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            grillaGenero.DataSource = null;
            grillaGenero.DataSource = generoBLL.Listar();
        }

        private Genero Leer()
        {
            return new Genero
            {
                 Fecha_reg = DateTime.Now,
                 Nombre = txt_nombre_genero.Text.Trim()
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_alta_genero_Click(object sender, EventArgs e)
        {
            var genero = Leer();
            generoBLL.Alta(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_nombre_genero.Text = string.Empty;
        }

        private Genero Seleccionar()
        {
            return (Genero)grillaGenero.SelectedRows[0].DataBoundItem;
        }

        private void btn_baja_genero_Click(object sender, EventArgs e)
        {
            var genero = Seleccionar();
            generoBLL.Baja(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void btn_modificacion_genero_Click(object sender, EventArgs e)
        {
            var genero = Seleccionar();
            genero.Nombre = txt_nombre_genero.Text.Trim();
            generoBLL.Modificar(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }
    }
}
