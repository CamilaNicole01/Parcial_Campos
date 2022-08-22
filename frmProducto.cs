using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenParcial_CamposArias
{
    public partial class frmProducto : Form
    {
        string cadenaConexion = " server=localhost; database=ParcialCampos; Integrated Security=true ";
        SqlDataAdapter daProducto;
        SqlConnection conexion;
        DataTable dtProducto;

        //constructor del formulario
        public frmProducto()
        {
            InitializeComponent();
            //Creamos la instancia de DataTable
            dtProducto = new DataTable();

            //
            var cadenaConexion = " server=localhost; database=ParcialCampos; Integrated Security=true ";
            conexion = new SqlConnection(cadenaConexion);

            //Crear un objeto DataAdapter
            daProducto = new SqlDataAdapter();

            //Metodos del Adaptador SELECT
            daProducto.SelectCommand =
                new SqlCommand("SELECT * FROM Producto", conexion);

            //Metodos del Adaptador INSERT inserccion
            daProducto.InsertCommand =
                new SqlCommand("INSERT INTO Producto(Nombre, Estado) VALUES(@nombre, @estado)", conexion);
            //Definir parametro de IJNSERT
            daProducto.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 20, "Nombre");
            daProducto.InsertCommand.Parameters.Add("@estado", SqlDbType.TinyInt, 10, "Estado");

            //Metodo de actualizacion con parametros
            daProducto.UpdateCommand =
                new SqlCommand("UPDATE Producto SET Nombre=@nombre, Estado=@estado WHERE ID=@id", conexion);
            daProducto.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 20, "Nombre");
            daProducto.UpdateCommand.Parameters.Add("@estado", SqlDbType.TinyInt, 10, "Estado");
            daProducto.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "ID");
        }
        //cuando se carga el formulario
        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            //Limpiar DataTable
            dtProducto.Clear();
            //Llenar datos al DataTable
            daProducto.Fill(dtProducto);
            //Enlazar el DataGridView con el DataTable
            dgvListado.DataSource = dtProducto;
        }
      

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmProductoEdit();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var nombre = ((TextBox)frm.Controls["txtNombre"]).Text;
                var marca = ((TextBox)frm.Controls["txtMarca"]).Text;
                var precio = ((TextBox)frm.Controls["txtPrecio"]).Text;
                var stock = ((TextBox)frm.Controls["txtStock"]).Text;
                var categoria = ((ComboBox)frm.Controls["cboCate"]).SelectedValue.ToString();

                using(var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "INSERT INTO Producto (IdProducto ,Nombre, Marca, " +
                        "Precio, Stock, Observacion, Foto, IdCategoria) " +
                        "VALUES(@Producto, @nombre, @marca, @precio, " +
                        "@stock, @observacion, @foto, @idCat)";

                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        
            }
    }
            }
        }
    }
}
