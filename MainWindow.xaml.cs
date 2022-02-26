using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using MahApps.Metro.Controls;

using DownloadSorterLibrary;


namespace DownloadSorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        CurrentTask CTask;
        string path = KnownFolders.GetPath(KnownFolder.Downloads);


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            string fileListC = String.Empty;
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    fileListC += f.Name + "\n";
                }
                fileList.Text = fileListC;
            }
        }

        private void BtnSortZips_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach(var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Archive, f, path);
                }
            }
        }

        private void BtnSortVids_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Video, f, path);
                }
            }
        }

        private void BtnSortPictures_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Picture, f, path);
                }
            }
        }

        private void BtnSortExe_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Executable, f, path);
                }
            }
        }

        private void BtnSortDocs_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Documents, f, path);
                }
            }
        }

        private void BtnSortCode_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                DirectoryInfo currentD = new DirectoryInfo(path);
                foreach (var f in currentD.GetFiles())
                {
                    FileExtensions.CheckAndMove(ExtensionFlags.Code, f, path);
                }
            }
        }

        private async void BtnToggleAsync_Checked(object sender, RoutedEventArgs e)
        {
            CTask = new CurrentTask();
        }

        private async void BtnToggleAsync_Unchecked(object sender, RoutedEventArgs e)
        {
            CTask.Cancel();
            CTask = null;
        }
    }
}