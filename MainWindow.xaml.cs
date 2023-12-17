using Microsoft.Win32;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> imagePaths = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeImageListBox();
        }
        private void InitializeImageListBox()
        {
            imageListBox.ItemsSource = imagePaths;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                imagePaths.Add(imagePath);
            }
        }

        private void ImageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imageListBox.SelectedItem != null)
            {
                string selectedImagePath = imageListBox.SelectedItem.ToString();
                DisplayImage(selectedImagePath);
            }
        }

        private void DisplayImage(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
            imageControl.Source = bitmapImage;
        }

        private void sizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (imageControl.Source != null)
            {
                double newSize = sizeSlider.Value;
                imageControl.Width = imageControl.Source.Width * newSize;
                imageControl.Height = imageControl.Source.Height * newSize;
            }
        }

        private void transparencySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (imageControl.Source != null)
            {
                double newOpacity = 1 - transparencySlider.Value;
                imageControl.Opacity = newOpacity;
            }
        }
    }
}
