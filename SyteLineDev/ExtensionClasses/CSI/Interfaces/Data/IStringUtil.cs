using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IStringUtil
    {
        string Right<T>(T input, int? length);
        string Left<T>(T input, int? length);
        int? CharIndex<T>(string search, T input, int? start = 0);
        int? Len<T>(T input);
        byte Ascii(string input);
        char Char(byte input);
        string Stuff(string input, int start, int length, string replacement);
        int Unicode(string input);
        string Reverse<T>(T input);
        string Replicate(string input, int? repeat);
        string Str<T>(T input, int? length = 10, int? decimalPlaces = 0);
        int PatIndex(string search, string input);
        T IsNull<T>(T input, T replacement);
        int IsNumeric<T>(T input);
        bool In<T>(T input, object[] collection);
        bool NotIn<T>(T input, object[] collection);
        bool Like(string input, string pattern, bool notDefined = false, bool odbcEscape = false, string escapeExpression = "");
        T Coalesce<T>(params object[] input);
        string QuoteName<T>(T input, string quoteChar = null);
        char NChar(byte input);
        string Substring<T>(T input, int? start, int? length);
        string Replace<T>(T input, string search, string replace);        
        string Format<T>(T input, object style);
        string Format<T>(T input, object style, object cultureInfo);
        string RTrim<T>(T input);
        string LTrim<T>(T input);
        string Trim<T>(T input);
        string Upper<T>(T input);
        string Lower<T>(T input);
        int? DataLength<T>(T input);
        string Concat(params object[] multipleStrings);
        string Space<T>(T length);
    }
}
