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
using System.Diagnostics.CodeAnalysis;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
namespace AntiDebugging
{
    public static class HardwareHelper
    {
        private static string FingerPrint { get; set; }
        public static IPAddress Ip()
        {
            var wc = new WebClient();
            var strInternetProtocol = wc.DownloadString("https://ipv4.wtfismyip.com/text");
            if (IPAddress.TryParse(strInternetProtocol.Trim(), out var ip))
                return ip;
            return null;
        }
        public static string HardwareUniqueId()
        {
            return FingerPrint ??= GetMd5Hash("CPU >> " + CpuId() + "\nVIDEO >> " + VideoId());
        }
        [SuppressMessage("ReSharper", "PossibleInvalidCastExceptionInForeachLoop")]
        private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            var result = "";
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
        [SuppressMessage("ReSharper", "PossibleInvalidCastExceptionInForeachLoop")]
        private static string Identifier(string wmiClass, string wmiProperty)
        {
            var result = "";
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private static string GetMd5Hash(this string s)
        {
            using MD5 sec = new MD5CryptoServiceProvider();
            var enc = new ASCIIEncoding();
            var bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(this byte[] bt)
        {
            var s = string.Empty;
            for (var i = 0; i < bt.Length; i++)
            {
                var b = bt[i];
                int n, n1, n2;
                n = b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + 'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + 'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        private static string CpuId()
        {
            var retVal = Identifier("Win32_Processor", "UniqueId");
            if (retVal == "") 
            {
                retVal = Identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") 
                {
                    retVal = Identifier("Win32_Processor", "Name");
                    if (retVal == "") 
                    {
                        retVal = Identifier("Win32_Processor", "Manufacturer");
                    }
                }
            }
            return retVal;
        }
        private static string BiosId()
        {
            return Identifier("Win32_BIOS", "Manufacturer")
            + Identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + Identifier("Win32_BIOS", "IdentificationCode")
            + Identifier("Win32_BIOS", "SerialNumber")
            + Identifier("Win32_BIOS", "ReleaseDate")
            + Identifier("Win32_BIOS", "Version");
        }
        private static string DiskId()
        {
            return Identifier("Win32_DiskDrive", "Model")
            + Identifier("Win32_DiskDrive", "Manufacturer")
            + Identifier("Win32_DiskDrive", "Signature")
            + Identifier("Win32_DiskDrive", "TotalHeads");
        }
        private static string BaseId()
        {
            return Identifier("Win32_BaseBoard", "Model")
            + Identifier("Win32_BaseBoard", "Manufacturer")
            + Identifier("Win32_BaseBoard", "Name")
            + Identifier("Win32_BaseBoard", "SerialNumber");
        }
        private static string VideoId()
        {
            return Identifier("Win32_VideoController", "DriverVersion") + Identifier("Win32_VideoController", "Name");
        }
        private static string MacId()
        {
            return Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
    }
}
