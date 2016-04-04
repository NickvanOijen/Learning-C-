using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;


namespace CpuMeterApp
{
    class Program
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        //
        //where al the magic happens!
        //
        static void Main(string[] args)
        {
            //list of messages that will be selected at random when CPU usage is 100% 
            List<string> cpuMaxedOutMessages = new List<string>();
            cpuMaxedOutMessages.Add("Warning CPU OVERLOAD DETECTED");
            cpuMaxedOutMessages.Add("Warning CPU FIRE DETECTED");
            cpuMaxedOutMessages.Add("WarninG STOP DOWNLOADING PORN");
            cpuMaxedOutMessages.Add("Warning HAMSTERPOWERED COMPUTER OVERLOADED");
            cpuMaxedOutMessages.Add("Warning YOUR FARTS ARE MAKING ME NUTS");

            //the dice!
            Random rand = new Random();


            //this will greet the user in default voice
            synth.Speak("Welcome to Cpu meter app version one point oh");

            #region My Performance Counters
            //This will pull the current CPU load in percentage
            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            perfCpuCount.NextValue();

            //This will get us the system uptime )in seconds'
            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();


            //This will pull the vurrent availble memory in megabytes
            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfMemCount.NextValue();
            #endregion

            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("The current system uptime is {0} days {1} hours {2} minutes {3} seconds",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes,
                (int)uptimeSpan.Seconds
                );

            //Tell the user what the system uptime is
            Speak(systemUptimeMessage, VoiceGender.Male, 2);

            int speechSpeed = 1;
            bool isChromeOpen = false;

            //infinite while loop
            while (true)
            {

               // get current performance counter values
                int currentCpuPercentage = (int)perfCpuCount.NextValue();
                int currentAvailableMemory = (int)perfMemCount.NextValue();

                //every one second print the CPU load in percentage on the screen
                Console.WriteLine("CPU load         :    {0}%", currentCpuPercentage);
                Console.WriteLine("Available Memory :    {0}GB", currentAvailableMemory);


                #region Logic
                // only speak when % is below 80
                if ( currentCpuPercentage > 80 )
                {
                    if (currentCpuPercentage == 100)
                    {
                        if (speechSpeed < 3)
                        {
                            speechSpeed++;
                        }
                        string cpuLoadVocalMessage = cpuMaxedOutMessages[rand.Next(5)];
                        
                        if(isChromeOpen == false )
                        {
                            OpenWebsite("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                            isChromeOpen = true;

                        }
                        Speak(cpuLoadVocalMessage, VoiceGender.Female, speechSpeed++);
                    }
                    else
                    {
                        string cpuLoadVocalMessage = string.Format("The current CPU load is {0} percent", currentCpuPercentage);
                        Speak(cpuLoadVocalMessage, VoiceGender.Male, speechSpeed++);
                    }
                }

                // only speak when memory is below 1gb
                if (currentAvailableMemory < 1024)
                {

                    // speak to the user with text 2 speach to tell them what the current values are
                    string memAvailableVocalMessage = string.Format("you currently have {0} Megabytes of memory available", currentAvailableMemory);
                    Speak(memAvailableVocalMessage, VoiceGender.Male, speechSpeed++);
                }
                #endregion

                Thread.Sleep(1000);
            }   //end of loop
        }
        /// <summary>
        /// Speaks with a selected voice
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param>
        public static void Speak(string message, VoiceGender voiceGender)
        {
                synth.SelectVoiceByHints(voiceGender);
                synth.Speak(message);
        }
        /// <summary>
        /// speaks with a selected voice at a selected rate
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param>
        /// <param name="rate"></param>
        public static void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);
        }
        //Open a Website
        public static void OpenWebsite(string URL)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URL;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();
        }
    }
}
