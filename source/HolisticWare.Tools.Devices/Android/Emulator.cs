using System.Diagnostics;

namespace HolisticWare.Tools.Devices.Android;

public partial class 
                                        Emulator
{
    // https://developer.android.com/studio/run/emulator-commandline
    protected static readonly
        string
                                        options_fast_load =
                                                            "-no-cache"
                                                            + " " +
                                                            "-gpu on"
                                                            + " " +
                                                            "-no-snapshot-load"
                                                            + " " +
                                                            "-no-boot-anim"
                                                            ;

    private static Process? process = default;
    
    public static Dictionary<string, Process> Processes
    {
        get;
        set;
    } = new Dictionary<string, Process>();

    public static
        EmulatorSettings
                                        Launch
                                        (
                                            string avd_name
                                        )
    {
        Thread stdoutThread = new Thread(new ThreadStart(WriteStandardOutput));
        stdoutThread.IsBackground = true;
        stdoutThread.Name = "holisticware_tools_devices_android_emulator_stdout_writer";
        stdoutThread.Start();

        string path = AndroidVirtualDeviceAVD.InstallRoot;
        
        process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = path,
                Arguments = $"-avd {avd_name} {options_fast_load}"
            }
        };
        
        process.Start();

        if (process is not null && ! process.HasExited)
        {
            Processes.Add(avd_name, process);
        }
        
        EmulatorSettings es = new EmulatorSettings();

        return es;
    }

    private static 
        void 
                                        WriteStandardOutput
                                        (
                                        )
    {
        return;
    }
}
