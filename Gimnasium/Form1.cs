using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasium
{
    public partial class Form1 : Form
    {
        string[] args;
        Audio audio;
        public Form1(string[] a)
        {
            args = a;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            foreach (Bell bell in Bell.bellList)
            {
                if (bell.time + ":00" == DateTime.Now.ToString("HH:mm:ss"))
                {
                    Thread myThread = new Thread(new ThreadStart(aup));
                    myThread.Start();      
                    
                    void aup()
                    {
                        audio.AudioPlayAsync("zvon.mp3");
                    }

                }
            }
        }

        private void buttonBell_Click(object sender, EventArgs e)
        {
            audio.AudioPlayAsync("zvon.mp3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            comboBoxIpAdress.Items.AddRange(Network.iPAddress);
            audio = Audio.getInstance();
            string adress = "http://" + Network.iPAddress + ":8888";
            if (args.Length > 0)
            {
                adress = "http://" + args[0] + ":8888";
            }
            _ = Network.Listen();
            Bell.bellList.Add(new Bell("8:00", "Первый урок"));
            Bell.bellList.Add(new Bell("8:45"));
            Bell.bellList.Add(new Bell("9:55", "Второй урок"));
            Bell.bellList.Add(new Bell("9:40"));
            Bell.bellList.Add(new Bell("9:50", "Третий урок"));
            Bell.bellList.Add(new Bell("10:35"));
            Bell.bellList.Add(new Bell("10:45", "Четвертый урок"));
            Bell.bellList.Add(new Bell("11:30"));
            Bell.bellList.Add(new Bell("16:35", "Проверка"));
        }
    }
}

