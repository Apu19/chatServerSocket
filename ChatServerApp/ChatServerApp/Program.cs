using ChatServerApp.Comunicación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando servidor en el puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    //esperar a que se conecte un cliente
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando conexion al cliente...");
                    if (servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cliente conectado :D");
                        Console.WriteLine("S: Hola cliente!");
                        servidor.Escribir("Hola cliente!");
                        string mensaje = servidor.Leer();
                        Console.WriteLine("C: {0}", mensaje);
                        servidor.CerrarConexion();
                    }
                }
        }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al iniciar el servidor, intente de nuevo");
                Console.ReadKey();
            }
        }
    }
}
