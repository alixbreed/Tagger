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
using Microsoft.Win32;

namespace Tagger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileName;
        TagLib.File file;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;
            }
            file = TagLib.File.Create(fileName);
            txtArtist.Text = file.Tag.FirstPerformer;
            txtTitle.Text = file.Tag.Title;
            txtAlbum.Text = file.Tag.Album;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            file.Tag.Performers[0] = txtArtist.Text;
            file.Tag.Title = txtTitle.Text;
            file.Tag.Album = txtAlbum.Text;
            try
            {
                file.Save();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Can't write to file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
