using System;
using System.Globalization;
using System.Threading;

namespace LinkedListDiary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TODO: mby add motd xD");

            string savePath = "./diary.json";

            var driver = new ConsoleDiaryDriver();
            var diary = new Diary();
            diary.Load(savePath);
            driver.Start(diary);
            diary.Save(savePath);
        }
    }
}
