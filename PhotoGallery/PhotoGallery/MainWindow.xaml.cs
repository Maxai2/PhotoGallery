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
        public ObservableCollection<ImageSource> pictures { get; set; }

        System.Windows.Forms.SaveFileDialog saveFileDialog;
        System.Windows.Forms.OpenFileDialog openFileDialog;
        FolderBrowserDialog folderDlg;
        //--------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            pictures = new ObservableCollection<ImageSource>();

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
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
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
                        ImageSource source = new BitmapImage(new Uri(pic.FullName));

                        

                        pictures.Add(source);
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
                Save();
            }
        }
        //--------------------------------------------
    }
}
//--------------------------------------------