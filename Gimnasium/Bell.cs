using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasium
{
    class Bell
    {
        public static List<Bell> bellList = new List<Bell>();
        private static int bellCount = 1;
        public int num;
        public string time;
        public string audioFilePath;
        public string comment;
        public bool finish;

        public Bell(string time, string comment = "", string audioFilePath = "zvon.mp3")
        {
            this.num = bellCount++;
            this.time = time;
            this.audioFilePath = audioFilePath;
            this.comment = comment;
        }
    }
}
