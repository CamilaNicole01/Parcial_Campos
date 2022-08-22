using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExamenParcial_CamposArias
{
    public partial class frmProductoEdit : Form
    {
        string cadenaConexion = " server=localhost; database=ParcialCampos; Integrated Security=true ";
        public frmProductoEdit()
        {
            InitializeComponent();
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        //CARGAR DATOS DE PRODUCTO
        private void cargarDatos()
        {

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "SELECT * FROM Producto";
                var commando = new SqlCommand(sql, conexion);
                var lector = commando.ExecuteReader();
                if(lector != null && lector.HasRows)
            {
                    Dictionary<string, string> ProductoSource = new Dictionary<string, string>();
                    while (lector.Read())
                    {
                        ProductoSource.Add(lector[0].ToString(), lector[1].ToString());
                    }
                    cboCate.DataSource = new BindingSource(ProductoSource, null);
                    cboCate.DisplayMember = "Value";
                    cboCate.ValueMember = "Key";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var value = cboCate.SelectedValue;
            MessageBox.Show(value.ToString());
        }
    }
}
