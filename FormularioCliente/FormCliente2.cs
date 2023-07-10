using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using System.Reflection.Emit;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace FormularioCliente
{
    public partial class FormCliente2 : Form
    {
        TcpClient remoto;
        StreamWriter escritor;
        StreamReader lector;
        delegate void actualizar(string texto);

        public FormCliente2()
        {
            InitializeComponent();
        }

        private void FormCliente2_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=edwinrea6dell;Initial Catalog=UsuariosPrueba;Integrated Security=True";

            IPAddress[] direccionesIP = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress direccionServidor = direccionesIP[0];
            //Console.WriteLine("Direcciones IP: ");
            //Luego, itera sobre las direcciones IP obtenidas y muestra todas las direcciones en la consola.
            foreach (IPAddress ip in direccionesIP)
            {
                //    Console.WriteLine(" * {0}", ip);
                // InterNetwork, establece esa dirección como la dirección del servidor.
                // También muestra en la consola la dirección del servidor y el puerto en el que está escuchando.
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (!ip.Equals("127.0.01"))
                        direccionServidor = ip;
                    //        Console.WriteLine("El servidor está escuchando en la dirección {0}, puerto 8080 ", ip);
                }
            }
            //Se crea un objeto IPEndPoint que representa la dirección IP y el puerto del servidor.
            IPEndPoint ipServidor = new IPEndPoint(direccionServidor, 8080);

            // Proceso para mandar la dirección IP a la base de datos
            string query = "INSERT INTO listaIP (str_ip) VALUES (@direccion)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@direccion", direccionServidor.ToString());
                        // Ejecutar la consulta SQL de inserción
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Su dirección IP se guardará en la base de datos.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar su dirección IP en la base de datos.");
                        }
                    }
                }
                catch(Exception)
                {

                }
                
            }


            remoto = new TcpClient();
            remoto.Connect(ipServidor);
            lblDireccionIP.Text = direccionServidor.ToString();
            Thread hilo = new Thread(Comunicaciones);
            hilo.Start();
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            escritor = new StreamWriter(remoto.GetStream());
            escritor.WriteLine(txtEnviar.Text);
            escritor.Flush();
            txtEnviar.Text = "";
            txtEnviar.Focus();
        }

      
        private void Comunicaciones()
        {
            lector = new StreamReader(remoto.GetStream());
            while (true)
            {
                string msg = lector.ReadLine();
                rtxtRecibido.Invoke(new actualizar(ActualizarTexto), new Object[] { msg });
            }
        }



        private void ActualizarTexto(string texto)
        {
            string[] datos = texto.Split(':');
            if (datos.Length == 1)
            {
                rtxtRecibido.AppendText("[" + DateTime.Now.ToShortDateString() + "]");
                //rtxtRecibido.AppendText("["+ DateTime.Now.ToShortTimeString() + "]", Color.Red);
                rtxtRecibido.AppendText(" ");
                rtxtRecibido.AppendText(texto);
                //rtxtRecibido.AppendText(texto, Color.Black);
                rtxtRecibido.AppendText(Environment.NewLine);
            }
            else
            {
                string nombre = datos[0];
                string msg = datos[1];
                // rtxtRecibido.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.Red);
                rtxtRecibido.AppendText("[" + DateTime.Now.ToShortTimeString() + "]");
                rtxtRecibido.AppendText(" ");
                //rtxtRecibido.AppendText(nombre, Color.Green);
                rtxtRecibido.AppendText(nombre);
                rtxtRecibido.AppendText(": ");
                //rtxtRecibido.AppendText(msg, Color.Blue);
                rtxtRecibido.AppendText(msg);
                rtxtRecibido.AppendText(Environment.NewLine);
            }
        }

    }

    public static class MiRichTextBoxExtension
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
