using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTunesLib;

namespace Itune.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            //var itunes = Activator.CreateInstance(Type.GetTypeFromProgID("iTunes.Application", true));
            //MessageBox.Show(itunes == null ? "error cant find itunes" : "ok");
            //IiTunes controller = new iTunesAppClass();
            //IITTrackCollection tracks = controller.LibraryPlaylist.Tracks;
            //var sb = new StringBuilder();
            //for (int i = 0; i < tracks.Count; i++)
            //{
            //    IITTrack track = tracks[i];
            //    if (track.Kind == ITTrackKind.ITTrackKindFile)
            //    {
            //        var fileTrack = (IITFileOrCDTrack)track;
            //        sb.AppendFormat("{0} is {1}\n", fileTrack.Name, fileTrack.Location);
            //    }
            //}
            //MessageBox.Show(sb.ToString());
        }
    }
}
