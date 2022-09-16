using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosTienda;
using EntidadTienda;

namespace ManejadorTienda
{
    public class ManejadorProducto
    {
        AccesoProducto ap = new AccesoProducto();
        
        
        public void Guardar(Producto producto) 
        {
            ap.Guardar(producto);
        }

        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 35;
            tabla.DataSource = ap.Mostrar(dato).Tables["producto"];

            tabla.Columns.Insert(4, boton("Editar", Color.Orange));
            tabla.Columns.Insert(5, boton("Eliminar", Color.Red));

            tabla.Columns[0].Visible = false;

        }

        DataGridViewColumn boton(string titulo, Color color)
        {
            DataGridViewButtonColumn c = new DataGridViewButtonColumn();
            c.Text = titulo;
            c.UseColumnTextForButtonValue = true;
            c.DefaultCellStyle.BackColor = color;
            return c;
        }
    }   
}
