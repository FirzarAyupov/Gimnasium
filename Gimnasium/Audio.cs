using NAudio.Wave;
using System.Threading;

namespace Gimnasium
{
    class Audio
    {
        private static Audio instance;

        private Audio() { }

        public static Audio getInstance()
        {
            if (instance == null)
                instance = new Audio();
            return instance;
        }

        public void AudioPlay(string file)
        {
            using (var audioFile = new AudioFileReader(file))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }


    }
}
