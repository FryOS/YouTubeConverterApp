﻿using System;
using YoutubeExplode;

namespace YouTubeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInfoAsync();
        }

        public static async void  GetInfoAsync()
        {
            var youtube = new YoutubeClient();
            var video = await  youtube.Videos.GetAsync("https://youtu.be/ErdJeQTpNbg");
            var title = video.Title; 
            var author = video.Author; 
            var duration = video.Duration;

            string text = $"Заголовок {title} Автор {author} Время {duration}";
            Console.WriteLine(text);
        }
    }
}
