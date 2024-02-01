using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HolisticWare.Tools.Devices.Android;

/// <summary>
/// 
/// </summary>
public partial class Genymotion
{
    public static readonly string HostLocalhost = "10.0.3.2";

    public static string? install_root = default; 

    public static string? InstallRoot 
    {
        get
        {   
            PlatformID os = System.Environment.OSVersion.Platform;

            install_root = GetInstallationPath(os.ToString());

            return install_root;
        }

        set
        {
            install_root = value;
        }
    }
    
    public static string GetInstallationPath (string os)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return "/Applications/Genymotion.app";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return @"C:\Program Files\Genymobile\Genymotion";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return "/usr/bin/genymotion";
        }
        else
        {
            throw new PlatformNotSupportedException();
        }
    } 
}
