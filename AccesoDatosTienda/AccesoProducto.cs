using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConectarBd;
using EntidadTienda;

namespace AccesoDatosTienda
{
    public class AccesoProducto
    {
        Base b = new Base("Localhost","root","","tienda");

        public void Guardar(Producto producto) 
        {
            b.Comando(String.Format("CALL insertarProducto( {0},'{1}','{2}',{3})", 
                producto.idProducto, 
                producto.nombre,
                producto.descripcion,
                producto.precio));
        }

        public DataSet Mostrar(string dato)
        {
            return b.Obtener(string.Format("SELECT * FROM producto WHERE nombre LIKE '%{0}%';", dato), "producto");
        }

    }
}
