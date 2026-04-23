using System;
using System.Collections.Generic;

class PlaylistManager
{
    LinkedList<string> playlist = new LinkedList<string>();
    SortedList<int, string> ratingList = new SortedList<int, string>();
    SortedDictionary<string, string> artistMap = new SortedDictionary<string, string>();

    public void AddSong(string song, int rating, string artist)
    {
        playlist.AddLast(song);
        ratingList[rating] = song;
        artistMap[artist] = song;
    }

    public void RemoveSong(string song)
    {
        playlist.Remove(song);

        foreach (var item in ratingList)
        {
            if (item.Value == song)
            {
                ratingList.Remove(item.Key);
                break;
            }
        }

        foreach (var item in artistMap)
        {
            if (item.Value == song)
            {
                artistMap.Remove(item.Key);
                break;
            }
        }
    }

    public void DisplayPlaylist()
    {
        foreach (var song in playlist)
            Console.WriteLine(song);
    }

    public void DisplayByRating()
    {
        foreach (var item in ratingList)
            Console.WriteLine(item.Key + " : " + item.Value);
    }

    public void DisplayByArtist()
    {
        foreach (var item in artistMap)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}

class Program
{
    static void Main()
    {
        PlaylistManager pm = new PlaylistManager();

        pm.AddSong("Shape of You", 5, "Ed Sheeran");
        pm.AddSong("Believer", 4, "Imagine Dragons");
        pm.AddSong("Kesariya", 3, "Arijit Singh");
        pm.AddSong("Blinding Lights", 4, "The Weeknd");

        Console.WriteLine("Playlist:");
        pm.DisplayPlaylist();

        Console.WriteLine("\nAfter Removing Believer:");
        pm.RemoveSong("Believer");
        pm.DisplayPlaylist();

        Console.WriteLine("\nSorted by Rating:");
        pm.DisplayByRating();

        Console.WriteLine("\nSorted by Artist:");
        pm.DisplayByArtist();
    }
}
