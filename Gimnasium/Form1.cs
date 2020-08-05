using System;
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
        Audio audio;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            comboBoxIpAdress.Items.AddRange(Network.iPAddress);
            audio = Audio.getInstance();
            _ = Network.Listen();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void buttonBell_Click(object sender, EventArgs e)
        {
            audio.AudioPlay("zvon.mp3");
        }
    }
}

