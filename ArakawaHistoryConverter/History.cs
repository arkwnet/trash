using System;
using System.Collections.Generic;

namespace ArakawaHistoryConverter
{
    class History
    {
        int year;
        int month;
        int day;
        List<string> content;

        public History(int year, int month, int day, List<string> content)
        {
            SetYear(year);
            SetMonth(month);
            SetDay(day);
            SetContent(content);
        }

        private void SetYear(int year)
        {
            this.year = year;
        }

        private void SetMonth(int month)
        {
            this.month = month;
        }

        private void SetDay(int day)
        {
            this.day = day;
        }

        private void SetContent(List<string> content)
        {
            this.content = new List<string>(content);
        }

        public string getDay()
        {
            return "    Date: \"" + year + "/" + string.Format("{0:00}", month) + "/" + string.Format("{0:00}", day) + "\",";
        }

        public string getContent()
        {
            string output = "";
            output += "    Content: [\n";
            for (int i = 0; i < content.Count; i++)
            {
                if (i < content.Count - 1)
                {
                    output += "      \"" + content[i].Replace("<br>", "") + "\",\n";
                }
                else
                {
                    output += "      \"" + content[i] + "\"\n";
                }
            }
            output += "    ]";
            return output;
        }
    }
}
