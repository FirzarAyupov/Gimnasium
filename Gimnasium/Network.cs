using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Gimnasium
{
    class Network
    {
        public static IPAddress[] iPAddress = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

        public static async Task Listen()
        {
            string adress = "http://192.168.2.44:8888/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(adress);
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;

                if (request.HttpMethod == "GET")
                {
                    if (request.QueryString.AllKeys.Contains("command"))
                    {
                        switch (request.QueryString["command"])
                        {
                            case "start":
                                //MessageBox.Show("Start");
                                break;
                            case "stop":
                                return;
                        }

                    }
                }
                HttpListenerResponse response = context.Response;

                string responseString = "<html><head><meta charset='utf8'></head><body><a href='" + adress + "?command=start'>Звонок</a></body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
