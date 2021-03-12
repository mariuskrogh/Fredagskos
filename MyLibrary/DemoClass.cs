using System;
using System.Collections.Generic;
using System.Linq;


namespace MyLibrary
{
    public class DemoClass
    {
        //2021-03-12
        public int GetYearByDateConvert(string isoDateString)
        {
            var date = Convert.ToDateTime(isoDateString);
            return date.Year;
        }

        public int GetYearByParseDate(string isoDateString)
        {
            var date = DateTime.Parse(isoDateString);
            return date.Year;
        }

        public int GetYearBySplit(string isoDateString)
        {
            return int.Parse(isoDateString.Split('-')[0]);
            
        }

        public int GetYearBySubstring(string isoDateString)
        {
            return int.Parse(isoDateString.Substring(0,4));

        }
        public int GetYear_SuperFast(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var index = dateTimeAsSpan.IndexOf('-');
            var yearAsASpan = dateTimeAsSpan.Slice(0, index);

            var temp = 0;
            for (int i = 0; i < yearAsASpan.Length; i++)
            {
                temp = temp * 10 + (yearAsASpan[i] - '0');
            }

            return temp;
        }

        public bool ContainsElementsWhere(List<int> list, int value)
        {
            return list.Where(x => x == value).Count() != 0;
        }
        public bool ContainsElementsCount(List<int> list, int value)
        {
            return list.Count(x => x == value) != 0;
        }
        public bool ContainsElementsAny(List<int> list, int value)
        {
            return list.Any(x => x == value);
        }
    }
}
