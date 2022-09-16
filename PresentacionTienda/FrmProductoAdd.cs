using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ManejadorTienda;
using EntidadTienda;

namespace PresentacionTienda
{
    public partial class FrmProductoAdd : Form
    {
        ManejadorProducto mp;
        public FrmProductoAdd()
        {
            InitializeComponent();
            mp = new ManejadorProducto();    

            //Recuperar datos de la entidad
            if (FrmProductos.producto.idProducto > 0)
            {
                txtNombre.Text = FrmProductos.producto.nombre;
                txtDescripcion.Text = FrmProductos.producto.descripcion;
                txtPrecio.Text = FrmProductos.producto.precio.ToString();
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            mp.Guardar(new Producto(
                FrmProductos.producto.idProducto,
                txtNombre.Text,
                txtDescripcion.Text,
                double.Parse(txtPrecio.Text)
                ));

            MessageBox.Show("Registro agregado");

            Close();
        }
    }
}
