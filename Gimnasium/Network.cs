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

        private static string style = "<style>
        *{
            font-family: Arial, Helvetica, sans-serif;
        }
        .button-response{
            border-radius: 5px;
            background-color: red;
            color: white;
            padding: 10px;
            display: block;
            text-align: center;
            text-decoration: none;
        }
table{
            margin-top: 10px;
            width: 100%;
        }
        
        table td, table th{
            padding: 5px;
            border-bottom: 1px solid #777;
        }
        form{
            margin-top: 10px;
            width: 100%;
            display: flex;
        }
        form input[type = submit], form input[type = time]{
            flex-grow: 1;
            font-size: 24px;
        }
        form input[type = time]{
            margin-right: 5px;
        }
        form input[type = submit]{
            margin-left: 5px;
            padding: 5px;
            font-size: 19px;
            background-color: green;
            color: white;
            border: none;
            border-radius: 5px;
        }

    </style>"

        public static async Task Listen(string adress = "")
        {
            if (iPAddress.Length > 0)
            {
                adress = adress.Length < 1 ? "http://" + iPAddress[0].ToString() + ":8888/":"http://localhost:8888/";
            }
            HttpListener listener = new HttpListener();
            //listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Prefixes.Add(adress);
            listener.Start();
            Console.WriteLine("Ожидание подключений..." + adress);

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
                                Audio audio = Audio.getInstance();
                                audio.AudioPlay("zvon.mp3");
                                break;
                            case "stop":
                                return;
                        }

                    }
                }
                HttpListenerResponse response = context.Response;

                string responseString = "<html><head><meta charset='utf8'></head><body><a href='" + adress + "?command=start'>Звонок</a></body></html>";
                string bellTable = "";
                foreach(Bell bell in Bell.bellList)
                {
                    bellTable += "<br>" + bell.num + " "
                        + bell.time + " "
                        + bell.comment;
                }
                responseString += bellTable;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
