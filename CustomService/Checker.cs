using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomService
{
    internal class Checker
    {
        bool enabled;
        Process[] processArray;
        Dictionary<string,string> forbidProcDict;
        public Checker()
        {
            enabled = true;
            forbidProcDict = new Dictionary<string,string>()
            {
                { "LeagueClient","Microsoft Edge" },
                { "RiotClientServices","Google Chrome" }
            };
        }

        public void Start()
        {
            var count = 0;
            processArray = Process.GetProcesses();
            while (enabled)
            {
                Thread.Sleep(250);
                processArray = Process.GetProcesses();
                var forbProcs = processArray.Where(p => forbidProcDict.Keys.Contains(p.ProcessName));
                if (forbProcs.Any())
                {
                    foreach (var forbProc in forbProcs)
                    {
                        string procPath = forbProc.MainModule.FileName;
                        Console.WriteLine($"Found! {forbProc.ProcessName} id:{forbProc.Id} {procPath}");
                        //forbProc.Kill();
                    }
                }
                else
                {
                    Console.WriteLine(count += 250);
                }

            }
        }

        public void Stop()
        {
            enabled = false;
        }

        public void Check()
        {
            processArray = Process.GetProcesses();
        }
    }
}
