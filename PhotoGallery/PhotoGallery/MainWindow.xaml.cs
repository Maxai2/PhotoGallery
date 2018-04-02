using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

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
        public ObservableCollection<ImageSource> pictures { get; set; }

        string CurrentDir;

        System.Windows.Forms.SaveFileDialog saveFileDialog;
        System.Windows.Forms.OpenFileDialog openFileDialog;
        System.Windows.Forms.FolderBrowserDialog folderDlg;
        //--------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            pictures = new ObservableCollection<ImageSource>();

            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Picture file (.jpg, .png)|*.jpg; *.png|*.png|*.png|*.jpg|*.jpg";

            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Picture file (.jpg, .png)|*.jpg; *.png|*.png|*.png|*.jpg|*.jpg";

            folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;


            var lb = new ListBox();
            lb.ItemTemplate = this.Resources["smallIconsTemplate"] as DataTemplate;
            lb.ItemsPanel = this.Resources["smaillIconsPanel"] as ItemsPanelTemplate;
        }
        //--------------------------------------------
        void Save(bool save)
        {
            if (save)
            {
                foreach (var item in pictures)
                {
                    string temp = Path.GetFullPath(item.ToString().Substring(8));

                    File.Copy(temp, temp, true);
                }
            }
            else
            {
                string path;

                folderDlg.ShowNewFolderButton = true;

                if (folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = folderDlg.SelectedPath;

                    foreach (var item in pictures)
                    {
                        string temp = Path.GetFullPath(item.ToString().Substring(8));

                        File.Copy(temp, Path.Combine(path.ToString(), Path.GetFileName(temp)), true);
                    }

                    CurrentDir = path;
                }

                folderDlg.ShowNewFolderButton = false;
            }
        }
        //--------------------------------------------
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                if (CurrentDir != "")
                    Save(false);
                else
                    Save(true);

                pictures.Clear();
            }
        }
        //--------------------------------------------
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                if (CurrentDir != "")
                    Save(false);
                else
                    Save(true);

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

                        pictures.Add(new BitmapImage(new Uri(pic.FullName)));
                    }
                }
            }
        }
        //--------------------------------------------
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                if (CurrentDir != "")
                    Save(true);
                else
                    Save(false);
            }
            else
                MessageBox.Show("No Laptop to save!");
        }
        //--------------------------------------------
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (pictures.Count != 0)
            {
                Save(false);
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
                        Save(false);
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
            //var img = sender as Button;

            var pWindow = new Preview(pictures, lbPictures.SelectedIndex) { Owner = this };

            //pWindow.PreviewImage.Source = img.Tag as ImageSource;
            pWindow.ShowInTaskbar = false;
            pWindow.WindowStyle = WindowStyle.ToolWindow;
            pWindow.ShowDialog();
        }
        //--------------------------------------------
        void AddFile()
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Picture picture = new Picture
                {
                    picSource = new BitmapImage(new Uri(openFileDialog.FileName))
                };

                pictures.Add(new BitmapImage(new Uri(openFileDialog.FileName)));
            }
        }
        //--------------------------------------------
        private void MenuAddFile_Click(object sender, RoutedEventArgs e)
        {
            AddFile();
        }
        //--------------------------------------------
        private void MenuAddFolder_Click(object sender, RoutedEventArgs e)
        {
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

                        pictures.Add(new BitmapImage(new Uri(pic.FullName)));
                    }
                }
            }
        }
        //--------------------------------------------
        private void lbPictures_Drop(object sender, DragEventArgs e)
        {
            Picture droppedPicture = e.Data.GetData(typeof(Picture)) as Picture;
            Picture tergetPicture = ((ListBoxItem)(sender)).DataContext as Picture;

            
        }
        //--------------------------------------------
        private void lbPictures_PreviewDrop(object sender, DragEventArgs e)
        {
           
        }
        //--------------------------------------------
    }
}
//--------------------------------------------