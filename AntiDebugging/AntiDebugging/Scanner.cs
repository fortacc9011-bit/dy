/*
THIS PROJECT LEAKED BY 

 /$            /       /              /
| $ $__  $ $          | $ $      | $ $             |__  $ $/
| $ $  \ $ $ /$$   /$$| $ $      | $ $        /$$$$$$ | $ $   
| $$$$$$$ | $ $  | $ $| $ $      | $ $       /$$__  $$| $ $   
| $ $__  $$| $ $  | $ $| $ $      | $ $      | $$$$$$$$| $ $   
| $ $  \ $ $| $ $  | $ $| $ $      | $ $      | $ $_____/| $ $   
| $$$$$$$/|  $$$$$$/| $$$$$$$$| $$$$$$$$|  $$$$$$$| $ $   
|_______/  \______/ |________/|________/ \_______/|__/   
                                                         
                                                         
                                                       
https://discord.gg/bt0
https://wwww.2m96.lol

Be Safe! If you buy this you have been scamed. :(
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace AntiDebugging
{
    public static class Scanner
    {
        private static HashSet<string> BadProcessNameList { get; set; }
        private static HashSet<string> BadWindowTextList { get; set; }
        public static void ScanAndKill()
        {
            try
            {
                Scan(true);
            }
            catch
            {
            }
        }
        private static int Scan(bool killBadProcess)
        {
            var isBadProcess = 0;
            if (BadProcessNameList.Any() != true ||
                BadWindowTextList.Any() != true)
            {
                Init();
            }
            var processList = Process.GetProcesses();
            foreach (var process in processList)
            {
                var mainTitle = process.MainWindowTitle.ToLower();
                var procName = process.ProcessName.ToLower();
                if (BadProcessNameList.Contains(procName))
                {
                    Debug.Write("BAD PROCESS FOUND: " + process.ProcessName);
                    isBadProcess++;
                    if (killBadProcess)
                    {
                        try { process.Kill(); } catch { }
                    }
                    continue;
                }
                if (!string.IsNullOrEmpty(mainTitle))
                {
                    if (procName == "firefox" || procName == "chrome" || procName == "msedge" || procName == "opera" || procName == "brave")
                    {
                        continue;
                    }
                    bool matchesBadWindow = false;
                    foreach (var badWindow in BadWindowTextList)
                    {
                        if (mainTitle.Contains(badWindow))
                        {
                            matchesBadWindow = true;
                            break;
                        }
                    }
                    if (matchesBadWindow)
                    {
                        Debug.Write("BAD WINDOW FOUND: " + process.MainWindowTitle + " (" + process.ProcessName + ")");
                        isBadProcess++;
                        if (killBadProcess)
                        {
                            try { process.Kill(); } catch { }
                        }
                    }
                }
            }
            return isBadProcess;
        }
        private static void Init()
        {
            if (BadProcessNameList?.Any() == true && BadWindowTextList?.Any() == true)
            {
                return;
            }
            BadProcessNameList = new HashSet<string>
            {
                "procmon64",
                "codecracker",
                "ida",
                "idag",
                "idaw",
                "idaq",
                "idau",
                "scylla",
                "de4dot",
                "de4dotmodded",
                "protection_id",
                "ollydbg",
                "x64dbg",
                "x32dbg",
                "x96dbg",
                "x64netdumper",
                "petools",
                "dnspy",
                "windbg",
                "reshacker",
                "simpleassembly",
                "process hacker",
                "process monitor",
                "qt5core",
                "importREC",
                "immunitydebugger",
                "megadumper",
                "cheatengine-x86_64",
                "dump",
                "dbgclr",
                "wireshark",
                "hxd"
            };
            BadWindowTextList = new HashSet<string>
            {
                "ollydbg",
                "ida",
                "disassembly",
                "scylla",
                "debug",
                "[cpu",
                "immunity",
                "windbg",
                "x32dbg",
                "x64dbg",
                "x96dbg",
                "import reconstructor",
                "dumper",
                "command prompt",
                "powershell",
                "python",
                "terminal",
                "cmd",
                "bash",
                "shell",
                "console",
                "command line",
                "administrator: command prompt",
                "windows powershell",
                "windows terminal",
                "visual studio code",
                "vscode",
                "pycharm",
                "jupyter",
                "ipython"
            };
        }
    }
}
