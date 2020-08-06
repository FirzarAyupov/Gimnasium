using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasium
{
    class Network
    {
        static string responseString;
        public static IPAddress[] iPAddress = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

        private static string htmlHead = @"
            <!DOCTYPE html>
            <html lang='ru'>
            <style>
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
                    }
                    form div{
                        font-size: 18px;
                    }
                    form input{
                        margin-top: 5px;
                        margin-bottom: 5px;
                    }
                    form input[type = submit]{
                        padding: 10px;
                        font-size: 14px;
                        background-color: green;
                        color: white;
                        border: none;
                        border-radius: 5px;
                    }
            </style>
            <head>
                <meta charset='utf-8'>
                <meta name = 'viewport' content='width=device-width, initial-scale=1.0'>
                <title>Система управления звонком</title>
            </head>
            <body>";        

        static string DecodertoUTF8(string text)
        {
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] utf8Bytes = win1251.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

            return win1251.GetString(win1251Bytes);
        }
        public static async Task Listen(string adress = "")
        {
            if (iPAddress.Length > 0)
            {
                adress = adress.Length < 1 ? "http://" + iPAddress[0].ToString() + ":8888/":"http://localhost:8888/";
            }
            HttpListener listener = new HttpListener();
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
                                audio.AudioPlayAsync("zvon.mp3");

                                break;
                            case "addbell":
                                if (request.QueryString.AllKeys.Contains("time"))
                                {
                                    Bell.bellList.Add(new Bell(request.QueryString["time"], DecodertoUTF8(request.QueryString["comment"])));
                                }
                                break;
                            case "stop":
                                return;
                        }

                    }
                }
                HttpListenerResponse response = context.Response;

                

                string htmlButton = "<a class='button-response' href='" + adress + "?command=start'>ЗВОНОК</a>";

                string htmlBellTable = "<table cellspacing='0' cellpadding='0'>";
                foreach(Bell bell in Bell.bellList)
                {
                    htmlBellTable += "<tr>";
                    htmlBellTable += "<td>" + bell.num + "</td><td>"
                        + bell.time + "</td><td>"
                        + bell.comment + "</td>";
                    htmlBellTable += "</tr>";
                }
                htmlBellTable += "</table>";

                string htmlAddBellForm = "<form action='" + adress + "addbell' method='GET'>" +
                                            "<input type = 'hidden' name = 'command' value = 'addbell'>" +
                                            "<div><label>Добавить время для звонка:</label><input type = 'time' name = 'time'></div>" +
                                            "<div><label>Комментарий:</label><input type = 'text' name = 'comment' value=''></div>" +
                                            "<input type = 'hidden' name = 'pass' value = 'DkmfRTY610'>" +
                                            "<input type = 'submit' value = 'Добавить'>" +
                                         "</form>";

                
                responseString = htmlHead + htmlButton + htmlBellTable + htmlAddBellForm + "</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
