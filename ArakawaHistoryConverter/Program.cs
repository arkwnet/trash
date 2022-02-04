// https://arkw.net/history.html をJavaScriptの連想配列に変換するツール
// (c) 2022 Sora Arakawa all rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArakawaHistoryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<History> history = new List<History>();
            StreamReader streamReader = new StreamReader("source.html");
            Boolean status = false;
            int year = 2000;
            int month = 1;
            int day = 1;
            List<string> content = new List<string>();
            string temp;
            while (streamReader.Peek() > -1)
            {
                temp = streamReader.ReadLine();
                if (status == false && temp == "<p>")
                {
                    status = true;
                }
                if (status == true)
                {
                    if (temp == "</p>")
                    {
                        if (content.Count > 0)
                        {
                            history.Add(new History(year, month, day, content));
                        }
                        content.Clear();
                        status = false;
                    }
                    else if (temp.Substring(0, 3) == "<b>")
                    {
                        year = int.Parse(temp.Substring(3, 4));
                        month = int.Parse(temp.Substring(8, 2));
                        day = int.Parse(temp.Substring(11, 2));
                    }
                    else if (temp != "<p>")
                    {
                        content.Add(temp);
                    }
                }
            }
            streamReader.Close();
            string output = "";
            for (int i = 0; i < history.Count; i++)
            {
                output = AddOutputText(output, "{");
                output = AddOutputText(output, history[i].getDay());
                output = AddOutputText(output, history[i].getContent());
                if (i == history.Count - 1)
                {
                    output = AddOutputText(output, "}");
                }
                else
                {
                    output = AddOutputText(output, "},");
                }
            }
            StreamWriter streamWriter = new StreamWriter("history.js", false, Encoding.UTF8);
            streamWriter.Write(output);
            streamWriter.Close();
            Console.WriteLine("変換処理が完了しました。何かキーを押すと終了します...");
            Console.ReadKey();
        }

        static string AddOutputText(string output, string text)
        {
            output += text + "\n";
            return output;
        }
    }
}
