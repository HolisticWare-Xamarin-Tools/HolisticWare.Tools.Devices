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

        string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string path_emulator = $"{home}\\Library\\Android\\sdk\\emulator\\emulator";

        process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = path_emulator,
                Arguments = $"-avd {avd_name} {options_fast_load}"
            }
        };
        
        process.Start();
        
        
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
