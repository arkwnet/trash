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
            this.SetYear(year);
            this.SetMonth(month);
            this.SetDay(day);
            this.SetContent(content);
        }
        public void SetYear(int year)
        {
            this.year = year;
        }
        public void SetMonth(int month)
        {
            this.month = month;
        }
        public void SetDay(int day)
        {
            this.day = day;
        }
        public void SetContent(List<string> content)
        {
            this.content = content;
        }
    }
}
