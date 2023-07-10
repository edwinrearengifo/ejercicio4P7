using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Collections;
using System.IO;

namespace servidor
{
    internal class ServidorChat
    {
        TcpListener servidor;
        public static Hashtable usuarios;
        public static Hashtable usuariosConectados;

        static void Main(string[] args)
        {
            ServidorChat programa = new ServidorChat();
        }

        public ServidorChat()
        {
            usuarios = new Hashtable(100);
            usuariosConectados = new Hashtable(100);
            servidor = new TcpListener(8080);

            while (true)
            {
                servidor.Start();
                if (servidor.Pending())
                {
                    TcpClient clienteChat = servidor.AcceptTcpClient();
                    Console.WriteLine("Cliente conectado");
                    ManejadorComunicaciones comunicaciones =
                        new ManejadorComunicaciones(clienteChat);
                }
            }
        }

        public static void EnviarTodos(string nick, string msg)
        {
            StreamWriter escritor;
            TcpClient[] clientes =
                new TcpClient[ServidorChat.usuarios.Count];
            ServidorChat.usuarios.Values.CopyTo(clientes, 0);
            for (int i = 0; i < clientes.Length; i++)
            {
                try
                {
                    if (msg.Trim() == "" || clientes[i] == null)
                        continue;
                    escritor =
                        new StreamWriter(clientes[i].GetStream());
                    escritor.WriteLine(nick + ": " + msg);
                    escritor.Flush();
                    escritor = null;
                }
                catch (Exception e)
                {
                    string str =
                        (string)ServidorChat.
                        usuariosConectados[clientes[i]];
                    ServidorChat.
                        EnviarMensaje("** " + str + " ** Ha salido.");
                    ServidorChat.usuarios.Remove(str);
                    ServidorChat.usuariosConectados.Remove(clientes[i]);
                }
            }
        }

        public static void EnviarMensaje(string msg)
        {
            StreamWriter escritor;
            TcpClient[] clientes =
                new TcpClient[usuarios.Count];
            usuarios.Values.CopyTo(clientes, 0);
            for (int i = 0; i < clientes.Length; i++)
            {
                try
                {
                    if (msg.Trim() == "" || clientes[i] == null)
                        continue;
                    escritor = new StreamWriter(clientes[i].GetStream());
                    escritor.WriteLine(msg);
                    escritor.Flush();
                    escritor = null;
                }
                catch (Exception e)
                {
                    usuarios.Remove(usuariosConectados[clientes[i]]);
                    usuariosConectados.Remove(clientes[i]);
                }
            }
        }
    }
}
