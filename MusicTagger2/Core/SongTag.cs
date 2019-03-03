﻿using System.Collections.Generic;
using System.Text;

namespace MusicTagger2.Core
{
    class SongTag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Dictionary<string, Song> songs = new Dictionary<string, Song>();

        public void CreateSong(string filePath)
        {
            var newSong = new Song(filePath);
            newSong.tags.Add(ID, this);
            songs.Add(filePath, newSong);
        }

        public void AddSong(Song song)
        {
            if (!songs.ContainsKey(song.FullPath))
                songs.Add(song.FullPath, song);

            song.AddTag(this);
        }

        public void RemoveFromSongs()
        {
            foreach (var s in songs)
                s.Value.tags.Remove(ID);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ID: {0}, Name: {1}, Category: {2}, SongNames: ", ID, Name, Category);
            foreach (var song in songs)
            {
                sb.Append(song.Value.FileName);
                sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}