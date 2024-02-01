using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolisticWare.Tools.Devices.Android;

/// <summary>
/// 
/// </summary>
/// <see cref="https://developer.android.com/studio/run/emulator-commandline"/>
/// <see cref="https://developer.android.com/studio/run/managing-avds"/>
public partial class AndroidVirtualDeviceAVD
{
    public static readonly string HostLocalhost = "10.0.2.2";

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
        string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string sdk = Environment.GetEnvironmentVariable("ANDROID_SDK_ROOT");

        return System.IO.Path.Combine
                                (
                                    sdk, 
                                    Path.Combine("emulator", "emulator")
                                );
    } 
}
