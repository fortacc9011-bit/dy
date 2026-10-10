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
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using AntiDebugging.WinStructs;
namespace AntiDebugging
{
    public static class SelfDebugger
    {
        public const int DbgContinue = 0x00010002;
        public const int DbgExceptionNotHandled = unchecked((int)0x80010001);
        static void DebuggerThread(object arg)
        {
            if (!AntiDebug.DebugActiveProcess((int)arg))
                throw new Win32Exception();
            while (true)
            {
                if (!AntiDebug.WaitForDebugEvent(out var evt, -1))
                    throw new Win32Exception();
                var continueFlag = SelfDebugger.DbgContinue;
                if (evt.dwDebugEventCode == DebugEventType.ExceptionDebugEvent)
                    continueFlag = SelfDebugger.DbgExceptionNotHandled;
                AntiDebug.ContinueDebugEvent(evt.dwProcessId, evt.dwThreadId, continueFlag);
            }
        }
        public static void DebugSelf(int ppid)
        {
            Console.WriteLine("Debugging {0}", ppid);
            var self = Process.GetCurrentProcess();
            if (ppid != 0)
            {
                var pdbg = Process.GetProcessById(ppid);
                new Thread(KillOnExit) { IsBackground = true, Name = "KillOnExit" }.Start(pdbg);
                WaitForDebugger();
                DebuggerThread(ppid);
                Environment.Exit(1);
            }
            else 
            {
                var procName = Environment.GetCommandLineArgs()[0];
                procName = procName.Replace(".dll", ".exe");
                var psi = new ProcessStartInfo(procName, self.Id.ToString())
                {
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    ErrorDialog = false,
                };
                var pdbg = Process.Start(psi);
                if (pdbg == null)
                    throw new ApplicationException("Unable to debug");
                new Thread(KillOnExit) { IsBackground = true, Name = "KillOnExit" }.Start(pdbg);
                new Thread(DebuggerThread) { IsBackground = true, Name = "DebuggerThread" }.Start(pdbg.Id);
                WaitForDebugger();
            }
        }
        static void WaitForDebugger()
        {
            var start = DateTime.Now;
            while (!AntiDebug.CheckDebuggerUnmanagedPresent() && 
                   !AntiDebug.CheckDebuggerManagedPresent() && 
                   !AntiDebug.CheckRemoteDebugger())
            {
                Console.WriteLine("Application working by self debugging...");
                if ((DateTime.Now - start).TotalMinutes > 1)
                    throw new TimeoutException("Debug operation timeout.");
                Thread.Sleep(1);
            }
        }
        static void KillOnExit(object process)
        {
            ((Process)process).WaitForExit();
            Environment.Exit(1);
        }
    }
}
