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
    public partial class FrmProductos : Form
    {
        ManejadorProducto mp;
        public static Producto producto = new Producto(0,"","",0);
        int columna = 0, fila = 0;

        public FrmProductos()
        {
            InitializeComponent();
            mp = new ManejadorProducto();
        }

        // Metodos 

        void Actualizar()
        {
            mp.Mostrar(dtgProductos, txtBuscar.Text);
        }

        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            producto.idProducto = int.Parse(dtgProductos.Rows[fila].Cells[0].Value.ToString());
            producto.nombre = dtgProductos.Rows[fila].Cells[1].Value.ToString();
            producto.descripcion = dtgProductos.Rows[fila].Cells[2].Value.ToString();
            producto.precio = double.Parse(dtgProductos.Rows[fila].Cells[3].Value.ToString());


            switch (columna)
            {
                case 4:
                    {
                        FrmProductoAdd fp = new FrmProductoAdd();
                        fp.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        //mp.Borrar(producto);
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            columna = e.ColumnIndex;
            fila = e.RowIndex;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            producto.idProducto = -1;
            FrmProductoAdd fpa = new FrmProductoAdd();
            fpa.ShowDialog();
            Actualizar();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
