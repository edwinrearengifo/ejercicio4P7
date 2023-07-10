using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace servidor
{
    internal class ManejadorComunicaciones
    {
        TcpClient cliente;
        StreamReader lector;
        StreamWriter escritor;
        
        string usuario;

        public ManejadorComunicaciones(TcpClient cliente)
        {
            this.cliente = cliente;
            Thread hiloComunicaciones =
                new Thread(new ThreadStart(ChatIniciado));
            hiloComunicaciones.Start();
        }

        private string ObtenerUsuario()
        {
            //string nombre = "copo";
            //lector.ReadLine();
            escritor.WriteLine("Ingresa un Alias ");
            //escritor.WriteLine(nombre);
            
           
            escritor.Flush();
            return lector.ReadLine();
        }
        private void ChatIniciado()
        {
            lector = new StreamReader(cliente.GetStream());
            escritor = new StreamWriter(cliente.GetStream());
            escritor.WriteLine("Bienvenido al chat!");
            usuario = ObtenerUsuario();
            //usuario = "copo";
            while (ServidorChat.usuarios.Contains(usuario))
            {
                escritor.
                    WriteLine("ERROR - Nombre de usuario existe! Ingresa uno nuevo");
                usuario = ObtenerUsuario();
            }
            
            ServidorChat.usuarios.Add(usuario, cliente);
            ServidorChat.usuariosConectados.Add(cliente, usuario);
            ServidorChat.
                EnviarMensaje("** " + usuario + " ** se ha conectado!");
            escritor.
                WriteLine("Empieza a escribir.....\r\n-------------------------------");
            escritor.Flush();
            Thread hiloUsuario =
                new Thread(new ThreadStart(ChatEnEjecucion));
            hiloUsuario.Start();
        }

        private void ChatEnEjecucion()
        {
            try
            {
                string dato = "";
                while (true)
                {
                    dato = lector.ReadLine();
                    ServidorChat.EnviarTodos(usuario, dato);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
