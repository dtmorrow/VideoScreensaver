using System.IO;

namespace VideoScreensaver
{
    class Config
    {
        // Config file will always be in the same directory as executable and named "Config.txt"
        internal static string ConfigPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\" + "Config.txt";

        // Identifiers for configuration
        private const string PATH_STRING = "PATH:";
        private const string VOLUME_STRING = "VOLUME:";

        internal struct ConfigOptions
        {
            public string VideoPath;
            public double Volume;
        }

        /// <summary>
        /// Writes a path to a video and volume to the configuration file
        /// </summary>
        /// <param name="videoPath">Path to video</param>
        /// <param name="volume">Volume, with 0.0 being silent and 1.0 being full volume</param>
        internal static void WriteConfig(string videoPath, double volume)
        {
            string[] options = new string[2];
            options[0] = "PATH:" + videoPath;
            options[1] = "VOLUME:" + volume.ToString();

            File.WriteAllLines(ConfigPath, options);
        }

        /// <summary>
        /// Reads configuration file and returns config options
        /// </summary>
        /// <returns>ConfigOptions struct with current configuration</returns>
        internal static ConfigOptions ReadConfig()
        {
            string[] options = File.ReadAllLines(ConfigPath);
            ConfigOptions co = new ConfigOptions();

            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].StartsWith(PATH_STRING))
                {
                    co.VideoPath = options[i].Substring(PATH_STRING.Length);
                }
                else if (options[i].StartsWith(VOLUME_STRING))
                {
                    co.Volume = double.Parse(options[i].Substring(VOLUME_STRING.Length));
                }
            }

            return co;
        }

        /// <summary>
        /// Checks if configuration file exists. If it doesn't, create one with an empty VideoPath and volume of 1.0
        /// </summary>
        internal static void CheckConfig()
        {
            if (!File.Exists(ConfigPath))
            {
                WriteConfig("", 1);
            }
        }
    }
}
