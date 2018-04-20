using System;
using System.Windows;
using System.Windows.Input;

namespace VideoScreensaver
{
    /// <summary>
    /// Interaction logic for Screensaver.xaml
    /// </summary>
    public partial class ScreensaverWindow : Window
    {
        public ScreensaverWindow()
        {
            InitializeComponent();

            var options = Config.ReadConfig();
            ScreensaverVideo.Source = new Uri(options.VideoPath);
            ScreensaverVideo.Volume = options.Volume;
        }

        private void PlayVideoFromBeginning(object sender, RoutedEventArgs e)
        {
            ScreensaverVideo.Position = new TimeSpan(0, 0, 0);
            ScreensaverVideo.Play();
        }

        private Point mouseLocation;
        private bool InitialMouseSet = true;
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (InitialMouseSet) // Mouse will always "move" when application starts. Use boolean to determine if initial load and set mouse position
            {
                mouseLocation = e.GetPosition(this);
                InitialMouseSet = false;
            }
            else
            {
                //Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.GetPosition(this).X) > 5 || Math.Abs(mouseLocation.Y - e.GetPosition(this).Y) > 5)
                {
                    Application.Current.Shutdown();
                }

                // Update current mouse location
                mouseLocation = e.GetPosition(this);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
