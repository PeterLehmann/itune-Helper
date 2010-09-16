/*
 *  Copyright 2010 Peter Lehmann Licensed under the Apache License, Version 2.0 (the "License"); 
 *  you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 
 *  Unless required by applicable law or agreed to in writing, software distributed under the 
 *  License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 *  See the License for the specific language governing permissions and limitations under the License. 
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTunesLib;

namespace ituneclr
{
    public class Program
    {
        static void Main(string[] args)
        {
            if(args == null
                || args.Length < 1)
            {
                ShowHelp();
                return;
            }
            var fileName = args[0];
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            ReadTracks(fileName);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("need file name as args");    
        }

        private static void ReadTracks(string fileName)
        {
            var controller = (IiTunes)Activator.CreateInstance(Type.GetTypeFromProgID("iTunes.Application", true));
            IITTrackCollection tracks = controller.LibraryPlaylist.Tracks;
            Console.WriteLine("there is {0} tracks", tracks.Count);
            using (var file = File.CreateText(fileName))
            {
                var list = new List<TrackInfo>();
                for (int i = tracks.Count; i > 0; i--)
                {
                    var track = tracks[i];
                    var trackInfo = new TrackInfo {Title = track.Name};
                    if (track.Kind == ITTrackKind.ITTrackKindFile)
                    {
                        var fileTrack = (IITFileOrCDTrack)track;
                        trackInfo.FilePath = fileTrack.Location;
                        Console.WriteLine("\"{0}\" is \"{1}\"\n", fileTrack.Name, fileTrack.Location);
                    }
                    else
                    {
                        Console.WriteLine("\"{0}\" is {1}", track.Name, track.KindAsString);
                    }
                    list.Add(trackInfo);
                    
                }
                var orderedList =
                    list.OrderBy(x => x.Title, StringComparer.InvariantCultureIgnoreCase);
                foreach (var orderedTrack in orderedList)
                {
                    file.WriteLine(orderedTrack);
                }   
            }
        }
    }

    public class TrackInfo
    {
        public string Title { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|\t{1}", Title, FilePath);
        }
    }
}
