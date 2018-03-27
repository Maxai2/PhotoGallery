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

namespace PhotoGallery
{
    /// <summary>
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        ObservableCollection<ImageSource> tempCol;

        public Preview(ObservableCollection<ImageSource> collection)
        {
            InitializeComponent();

            tempCol = collection;
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var controll = sender as Button;

            switch (controll == )
            {
                default:
            }
        }
    }
}
