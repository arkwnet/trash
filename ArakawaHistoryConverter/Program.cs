// https://arkw.net/history.html をJavaScript配列に変換するツール
// (c) 2022 Sora Arakawa all rights reserved.

using System;
using System.Collections.Generic;
using System.IO;

namespace ArakawaHistoryConverter
{
    class Program
    {
        static List<History> history = new List<History>();
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("source.html");
            Boolean status = false;
            int year = 2000;
            int month = 1;
            int day = 1;
            List<string> content = new List<string>();
            string temp = "";
            while (streamReader.Peek() > -1)
            {
                temp = streamReader.ReadLine();
                if (status == false && temp == "<p>")
                {
                    content.Clear();
                    status = true;
                }
                if (status == true)
                {
                    if (temp == "</p>")
                    {
                        AddList(year, month, day, content);
                        status = false;
                    }
                    else if (temp.Substring(0, 3) == "<b>")
                    {
                        year = int.Parse(temp.Substring(3, 4));
                        month = int.Parse(temp.Substring(8, 2));
                        day = int.Parse(temp.Substring(11, 2));
                    }
                    else
                    {
                        content.Add(temp);
                    }
                }
            }
            streamReader.Close();
            Console.WriteLine("変換処理が完了しました。何かキーを押すと終了します...");
            Console.ReadKey();
        }
        static void AddList(int year, int month, int day, List<string> content)
        {
            history.Add(new History(year, month, day, content));
        }
    }
}
