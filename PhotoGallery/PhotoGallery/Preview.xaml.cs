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

        int curIndex;
        //-------------------------------------------------------
        public Preview(ObservableCollection<ImageSource> sources, int cur)
        {
            InitializeComponent();

            tempCol = sources;
            curIndex = cur;

            iPreviewImage.Source = tempCol[curIndex];
        }
        //-------------------------------------------------------
        private void ButtonPreview_Click(object sender, RoutedEventArgs e)
        {
            if (curIndex >= 0)
            {
                curIndex--;

                iPreviewImage.Source = tempCol[curIndex];
            }
        }
        //-------------------------------------------------------
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {

        }
        //-------------------------------------------------------
        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {

        }
        //-------------------------------------------------------
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {

        }
        //-------------------------------------------------------
    }
}
