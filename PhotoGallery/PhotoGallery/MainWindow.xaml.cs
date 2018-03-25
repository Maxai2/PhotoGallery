using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;
//--------------------------------------------
namespace PhotoGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Picture> pictures { get; set; }

        System.Windows.Forms.SaveFileDialog saveFileDialog;
        System.Windows.Forms.OpenFileDialog openFileDialog;
        FolderBrowserDialog folderDlg;
        //--------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            pictures = new ObservableCollection<Picture>();

            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Picture file (.jpg, .png)|*.jpg; *.png|*.png|*.png|*.jpg|*.jpg";

            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Picture file (.jpg, .png)|*.jpg; *.png|*.png|*.png|*.jpg|*.jpg";

            folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
        }
        //--------------------------------------------
        void Save()
        {
            StringBuilder path = new StringBuilder();

            folderDlg.ShowNewFolderButton = true;

            if (folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path.Clear();

                path.Append(folderDlg.SelectedPath);

                foreach (var item in pictures)
                {
                    File.Copy(item.picSource.ToString(), path.ToString() + item.picSource.ToString().Substring(item.picSource.ToString().LastIndexOf('/')), true);
                }
            }

            folderDlg.ShowNewFolderButton = false;
        }
        //--------------------------------------------
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                Save();
            }
        }
        //--------------------------------------------
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                Save();
                pictures.Clear();
            }


            if (folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo directory = new DirectoryInfo(folderDlg.SelectedPath);

                if (directory.Exists)
                {
                    foreach (FileInfo pic in directory.GetFiles())
                    {
                        Picture picture = new Picture
                        {
                            picSource = new BitmapImage(new Uri(pic.FullName))
                        };

                        pictures.Add(picture);
                    }
                }
            }
        }
        //--------------------------------------------
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                Save();
            }
        }
        //--------------------------------------------
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                Save();
            }
        }
        //--------------------------------------------
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                var ans = System.Windows.MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.YesNoCancel);

                switch (ans)
                {
                    case MessageBoxResult.Yes:
                        Save();
                        return;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.None:
                    case MessageBoxResult.Cancel:
                        return;
                }

                PhotoGalleryWindow.Close();
            }
            else
                PhotoGalleryWindow.Close();

        }
        //--------------------------------------------
        private void Button_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var img = e.OriginalSource as Image;

            var pWindow = new Preview { Owner = this };
            pWindow.PreviewImage.Source = img.Source;
            pWindow.Show();
        }
        //--------------------------------------------
    }
}
//--------------------------------------------