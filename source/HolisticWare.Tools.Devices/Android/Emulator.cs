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
                                                            "-no-snapshot-save"
                                                            // + " " +
                                                            // "-no-snapshot-load"
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
        // https://stackoverflow.com/questions/29684798/c-sharp-redirecting-process-results-to-a-text-file
        // https://stackoverflow.com/questions/18588659/redirect-process-output-c-sharp

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
        process.OutputDataReceived += new DataReceivedEventHandler(Launch_ErrorDataReceived);
        process.ErrorDataReceived += new DataReceivedEventHandler(Launch_OutputDataReceived);
        
        process.Start();

        if (process is not null && ! process.HasExited)
        {
            Processes.Add(avd_name, process);
        }
        
        EmulatorSettings es = new EmulatorSettings();

        return es;
    }

    private static 
        void                            Launch_OutputDataReceived
                                        (
                                            object sender, 
                                            DataReceivedEventArgs e
                                        )
    {
        throw new NotImplementedException();
    }

    private static 
        void 
                                        Launch_ErrorDataReceived
                                        (
                                            object sender, 
                                            DataReceivedEventArgs e
                                        )
    {
        throw new NotImplementedException();
    }

    private static 
        void 
                                        WriteStandardOutput
                                        (
                                        )
    {
        return;
    }


    public static
        List<string>
                                        List
                                        (
                                        )
    {
        // $HOME/.android/avd
        //      Pixel_3a_API_34_extension_level_7_arm64-v8a.avd
        //      Pixel_3a_API_34_extension_level_7_arm64-v8a.ini
        //      nexus_9_api_33.avd
        //      nexus_9_api_33.ini

        return new List<string>();
    }
}
