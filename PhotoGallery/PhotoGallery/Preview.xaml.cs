using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
//-------------------------------------------------------
namespace PhotoGallery
{
    /// <summary>
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        ObservableCollection<ImageSource> tempCol;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        int curIndex;
        //-------------------------------------------------------
        public Preview(ObservableCollection<ImageSource> sources, int cur)
        {
            InitializeComponent();

            tempCol = sources;
            curIndex = cur;

            iPreviewImage.Source = tempCol[curIndex];

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }
        //-------------------------------------------------------
        void NextImage()
        {
            if (curIndex < tempCol.Count - 1)
            {
                curIndex++;

                iPreviewImage.Source = tempCol[curIndex];
            }
        }
        //-------------------------------------------------------
        void dispatcherTimer_Tick(object sender, EventArgs e) => NextImage();
        //-------------------------------------------------------
        private void ButtonPreview_Click(object sender, RoutedEventArgs e)
        {
            if (curIndex > 0)
            {
                curIndex--;

                iPreviewImage.Source = tempCol[curIndex];
            }
        }
        //-------------------------------------------------------
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
        //-------------------------------------------------------
        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }
        //-------------------------------------------------------
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            NextImage();
        }
        //-------------------------------------------------------
    }
}
