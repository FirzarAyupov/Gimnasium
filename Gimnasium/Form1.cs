using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
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
            DataBase.getAllTime();

            tableBell.DataSource = DataBase.getDS();

            timer1.Enabled = true;
            comboBoxIpAdress.Items.AddRange(Network.iPAddress);
            audio = Audio.getInstance();
            string adress = Network.iPAddress[0].ToString();
            if (args.Length > 0)
            {
                adress = args[0];
            }
            _ = Network.Listen(adress);
        }
    }
}

