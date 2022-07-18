using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_tienda
{
    public partial class Tienda : Form
    {
        public Tienda()
        {
            InitializeComponent();
        }

        private void productosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tiendaDataSet);

        }

        private void Tienda_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tiendaDataSet.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.tiendaDataSet.productos);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.productosTableAdapter.Insertar(productoTextBox.Text, descripcionTextBox.Text, precioTextBox.Text);
            this.productosTableAdapter.Fill(this.tiendaDataSet.productos);
            productoTextBox.Text = "";
            descripcionTextBox.Text = "";
            precioTextBox.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.productosTableAdapter.Modificar(productoTextBox.Text, descripcionTextBox.Text, precioTextBox.Text, productoTextBox.Text);
            this.productosTableAdapter.Fill(this.tiendaDataSet.productos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.productosTableAdapter.Eliminar(productoTextBox.Text);
            this.productosTableAdapter.Fill(this.tiendaDataSet.productos);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.productosTableAdapter.Buscar(tiendaDataSet.productos, productoTextBox.Text);
        }
    }
}
