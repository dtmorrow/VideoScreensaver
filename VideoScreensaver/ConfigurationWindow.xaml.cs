using Microsoft.Win32;
using System.Windows;

namespace VideoScreensaver
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        // Fill out fields from current config
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var options = Config.ReadConfig();
            VideoPathTextbox.Text = options.VideoPath;
            VolumeSlider.Value = options.Volume * 100;
        }

        // Save changes to config
        private void ConfirmConfig(object sender, RoutedEventArgs e)
        {
            Config.WriteConfig(VideoPathTextbox.Text, VolumeSlider.Value / 100);
            Close();
        }

        // Discard changes
        private void CancelConfig(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Open dialog and select file
        private void BrowseVideo(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.Multiselect = false;
            open.ShowDialog();
            VideoPathTextbox.Text = open.FileName;
        }

        
    }
}
