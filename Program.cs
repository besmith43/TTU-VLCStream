using System;

namespace TTU_VLCStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string vlcExe;
            string vlcArgs = @"screen:// --screen-fps=30 --screen-caching=300 --screen-width=1920 --screen-height=1080 --sout=""#transcode{vcodec=h264,acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}:rtp{dst=239.0.0.1,port=4570,mux=ts}"" --no-sout-all --sout-keep -I dummy --ttl 12";

            if (System.IO.File.Exists(@"C:\Program Files\VideoLAN\VLC\vlc.exe"))
            {
                vlcExe = @"C:\Program Files\VideoLAN\VLC\vlc.exe";
            }
            else if (System.IO.File.Exists(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe"))
            {
                vlcExe = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";
            }
            else
            {
                Console.WriteLine("VLC is not installed");
                return;
            }

            #if DEBUG
                Console.WriteLine($"{ vlcExe } {vlcArgs }");
            #endif

            System.Diagnostics.Process.Start(vlcExe, vlcArgs);
        }
    }
}
