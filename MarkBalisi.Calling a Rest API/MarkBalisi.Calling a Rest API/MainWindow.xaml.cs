using Newtonsoft.Json;
using RestSharp;
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

namespace MarkBalisi.Calling_a_Rest_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowPhotos();
        }
        private void ShowPhotos()
        {
            var Client = new RestClient("https://jsonplaceholder.typicode.com/photos/38");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);

            var content = response.Content;

            var data = JsonConvert.DeserializeObject<photos>(content);
            lblAlbumId.Content = "AlbumId: " + data.albumId;
            lblId.Content = "Id: " + data.id;
            lblTitle.Content = "Title: " + data.title;
            lblUrl.Content = "Url: " + data.url;
            lblThumbnailUrl.Content = "ThumbnailUrl: " + data.thumbnailUrl;
        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            ShowPhotos();
        }
    }
}
