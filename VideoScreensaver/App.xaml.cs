using System;
using System.Windows;

namespace VideoScreensaver
{
    // Code adapted from: https://www.harding.edu/fmccown/screensaver/screensaver.html

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Config.CheckConfig();
            if (e.Args.Length > 0)
            {
                string firstArgument = e.Args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (e.Args.Length > 1)
                {
                    secondArgument = e.Args[1];
                }

                if (firstArgument == "/c")      // Configuration mode
                {
                    ConfigurationWindow ConfigWindow = new ConfigurationWindow();
                    ConfigWindow.Closed += CloseApplication;
                    ConfigWindow.Show();
                }
                else if (firstArgument == "/p") // Preview mode
                {
                    Current.Shutdown(); // Not worried about implementing preview mode.
                }
                else if (firstArgument == "/s") // Full-screen mode
                {
                    ScreensaverWindow FullScreensaver = new ScreensaverWindow();
                    FullScreensaver.Closed += CloseApplication;
                    FullScreensaver.Show();
                }
                else    // Undefined argument
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + firstArgument + "\" is not valid.", "VideoScreensaver", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else    // No arguments, treat like /c
            {
                ConfigurationWindow ConfigWindow = new ConfigurationWindow();
                ConfigWindow.Closed += CloseApplication;
                ConfigWindow.Show();
            }
        }

        private void CloseApplication(object sender, EventArgs e)
        {
            Current.Shutdown();
        }
    }
}
