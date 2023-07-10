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
using Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FormularioCliente
{
    public partial class FormCliente1 : Form
    {
        TcpClient remoto;
        StreamWriter escritor;
        StreamReader lector;
        delegate void actualizar(string texto);

        public FormCliente1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Método para validar el ingreso

        public bool validarIngreso()
        {
            bool estadoValidacion = false;
            try
            {
                int idUsuario = int.Parse(txtID.Text);
                int telefonoUsuario = int.Parse(txtTelefono.Text);
                string connectionString = "Data Source=edwinrea6dell;Initial Catalog=UsuariosPrueba;Integrated Security=True"; // Cadena de conexión
                string query = "SELECT * FROM usuario WHERE int_id=@id AND int_telefono = @telefono";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", idUsuario);
                        command.Parameters.AddWithValue("@telefono", telefonoUsuario);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Si se encontró un registro con el ID especificado
                            {
                                string nombre = reader.GetString(3);
                                int telefono = reader.GetInt32(6);
                                txtTelefono.Text = telefono.ToString();
                                label2.Text = "Bienvenido " + nombre;
                                return estadoValidacion = true;
                            }
                            else
                            {
                                MessageBox.Show("No existe un registro con el ID: "+txtID.Text+" y Telefono: "+txtTelefono.Text);
                                return estadoValidacion;
                            }
                        }
                    }
                }
            } catch(Exception)
            {
                MessageBox.Show("Alguno de los campos está vacío. Llene los campos ID y Teléfono");
                return estadoValidacion;
            }


        }


        // Botón Conectar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //llamar al método de validación
            
            bool validacionObtenida = validarIngreso();
            if(validacionObtenida==true)
            {
                MessageBox.Show("Registro Exitoso");
                this.Hide();
                FormCliente2 formCliente2 = new FormCliente2();
                formCliente2.ShowDialog();

            }
        }

        private void FormCliente1_Load(object sender, EventArgs e)
        {

        }
    }
}
