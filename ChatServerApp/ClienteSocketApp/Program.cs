using ClienteSocketApp.Comunicación;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexión al servidor {0}");
            ClienteSocket clienteSocket = new ClienteSocket(puerto,ip);
            if (clienteSocket.Conectar())
            {
                string mensaje = "";
                while (mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("Ingrese lo que quiere enviar");
                    mensaje = Console.ReadLine().Trim();
                    clienteSocket.Escribir(mensaje);
                    if (mensaje.ToLower() != "chao")
                    {
                        mensaje = clienteSocket.Leer();
                        Console.WriteLine("S: {0}", mensaje);
                    }
                }
                clienteSocket.Desconectar();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al conectar con el servidor, intente de nuevo");
            }
        }
    }
}
