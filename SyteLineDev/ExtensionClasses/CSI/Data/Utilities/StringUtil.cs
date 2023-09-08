using CSI.Data.SQL.UDDT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSI.Data.Utilities
{
    public class StringUtil : IStringUtil
    {
        readonly IDataConverter dataConverter = new DataConverter();

        public string QuoteName<T>(T input, string quoteChar = null)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;

            if (objInput is null) return string.Empty;

            string inputValue = ConvertObjectToString(objInput);

            if (quoteChar == null)
            {
                //Bracket
                inputValue = inputValue.Replace("[", "[[").Replace("]", "]]");
                return $"[{inputValue}]";
            }
            else
            {
                var quoteCharCheck = quoteChar.Substring(0, 1);

                if ("[]".Contains(quoteCharCheck)) //Bracket
                {
                    inputValue = inputValue.Replace("[", "[[").Replace("]", "]]");
                    return $"[{inputValue}]";
                }
                else if ("'".Equals(quoteCharCheck)) //SingleQuote
                {
                    inputValue = inputValue.Replace("'", "''");
                    return $"'{inputValue}'";
                }
                else if ("\"".Equals(quoteCharCheck))  //DoubleQuote
                {
                    inputValue = inputValue.Replace("\"", "\"\"");
                    return $"\"{inputValue}\"";
                }
                else if ("()".Contains(quoteCharCheck))  //Parenthesis
                {
                    inputValue = inputValue.Replace("(", "((").Replace(")", "))");
                    return $"({inputValue})";
                }
                else if ("<>".Contains(quoteCharCheck))  //AngleBracket
                {
                    inputValue = inputValue.Replace("<", "<<").Replace(">", ">>");
                    return $"<{inputValue}>";
                }
                else if ("{}".Contains(quoteCharCheck))  //CurlyBrace
                {
                    inputValue = inputValue.Replace("{", "{{").Replace("}", "}}");
                    return $"{{{inputValue}}}";
                }
                else if ("`".Equals(quoteCharCheck))  //BackTick
                {
                    inputValue = inputValue.Replace("`", "``");
                    return $"`{inputValue}`";
                }
                else
                {
                    return null;
                }
            }
        }

        public string Right<T>(T input, int? length)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            string inputValue = ConvertObjectToString(objInput);

            var lengthValue = length.GetValueOrDefault();
            return length > inputValue.Length ? inputValue : inputValue.Substring(inputValue.Length - lengthValue, lengthValue);
        }

        public string Left<T>(T input, int? length)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            string inputValue = ConvertObjectToString(objInput);

            var lengthValue = length.GetValueOrDefault();
            return length > inputValue.Length ? inputValue : inputValue.Substring(0, lengthValue);
        }

        public int? CharIndex<T>(string search, T input, int? start = 0)
        {

            if (search is null) return null;
            if (input == null) return null;

            string inputValue = string.Empty;
            if (input is IUDDTType uddt)
                inputValue = ((string)ChangeType(uddt.Value, typeof(string))).ToLower();
            else
                inputValue = ((string)ChangeType(input, typeof(string))).ToLower();

            var searchValue = search.ToLower();
            if (inputValue.Length < start.GetValueOrDefault()) return 0;
            return start.GetValueOrDefault() == 0 ? inputValue.IndexOf(searchValue) + 1 : inputValue.IndexOf(searchValue, start.GetValueOrDefault() - 1) + 1;
        }

        public int? Len<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            string inputValue = ConvertObjectToString(objInput);

            return inputValue.TrimEnd(' ').Length;
        }

        public byte Ascii(string input)
        {
            return Encoding.ASCII.GetBytes(input)[0];
        }

        public char Char(byte input)
        {
            return (char)input;
        }

        public char NChar(byte input)
        {
            return Char(input);
        }

        public string Stuff(string input, int start, int length, string replacement)
        {
            return input.Remove(start - 1, length).Insert(start - 1, replacement);
        }

        public int Unicode(string input)
        {
            return (int)input.ToCharArray().ElementAt(0);
        }

        public string Reverse<T>(T input)
        {
            if (input is IUDDTType uDDT)
                if (uDDT.Value is null) return null;

            if (input == null) return null;


            var inputStr = input is IUDDTType ? ((IUDDTType)input).Value.ToString() : input.ToString();
            var isNumeric = decimal.TryParse(inputStr, out decimal inputDecimal);

            if (input is IUDDTType uDDTType && isNumeric)
            {
                var sqlDecimal = (SqlDecimal)inputDecimal;
                var precision = uDDTType.Precision;
                var scale = uDDTType.Scale;

                inputStr = SqlDecimal.ConvertToPrecScale(sqlDecimal, precision, scale).Value.ToString();
            }

            char[] charArray = inputStr.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string Replicate(string input, int? repeat)
        {
            if (repeat is null) return null;
            int count = Convert.ToInt32(repeat);
            return string.Concat(ArrayList.Repeat(input, count).ToArray());
        }

        public string Str<T>(T input, int? length = 10, int? decimalPlaces = 0)
        {
            //Checks for null
            var lengthValue = length ?? 10;
            var decimalValue = decimalPlaces ?? 0;

            if (input == null) return null;

            if (input is IUDDTType uDDT)
                if (uDDT.Value is null) return null;
            if (length is null) return null;
            if (length.Value == 0 && decimalPlaces.Value == 0) return null;

            //Converts to decimal
            var result = string.Empty;
            var inputValue = input is IUDDTType uDDTtype ? uDDTtype.Value.ToString() : input.ToString();
            decimal.TryParse(inputValue, out decimal inputDecimal);

            //cast to sqlDecimal for uddt purposes.
            var sqlDecimal = (SqlDecimal)inputDecimal;

            //if UDDT type, formats to correct precision and scale.
            if (input is IUDDTType uddtInput)
            {
                var precision = uddtInput.Precision;
                var scale = uddtInput.Scale;
                inputDecimal = SqlDecimal.ConvertToPrecScale(sqlDecimal, precision, scale).Value;
            }

            //Checks whether the length is less than the input and when only whole number.
            if ((lengthValue < inputDecimal.ToString().Length && (inputDecimal % 1) == 0) || length < Math.Truncate(inputDecimal).ToString().Length)
                return string.Empty.PadLeft(lengthValue).Replace(" ", "*");

            //Checks whether there's a need to format the decimal places.
            if (decimalValue != 0)
                result = String.Format($"{{0:F{decimalValue}}}", inputDecimal).Replace("0.", ".");
            else if (length == 10 && decimalValue == 0)
                result = Math.Round(inputDecimal, MidpointRounding.AwayFromZero).ToString();
            else
                result = inputDecimal.ToString();

            //Checks whether it still needs padding or not.
            if (result.Length == lengthValue)
                return result;
            else
            {
                if (result.IndexOf('.') == length)
                    result = Math.Round(Convert.ToDecimal(result), MidpointRounding.AwayFromZero).ToString();

                var tempResult = result.PadLeft(lengthValue).Substring(0, lengthValue);

                if (tempResult.LastIndexOf('.') == length - 1)
                {
                    result = Math.Round(Convert.ToDecimal(result), MidpointRounding.AwayFromZero).ToString();
                    return result.Substring(0, lengthValue - 1).PadLeft(lengthValue);
                }
                else
                    return tempResult;
            }
        }

        public int PatIndex(string search, string input)
        {
            int Index = -1;

            if (search.StartsWith("%")) //More characters before
            {
                if (search.EndsWith("%")) //More characters after
                {
                    if ((search.StartsWith("%[")) && (search.EndsWith("]%"))) //Match any single character within the brackets
                    {
                        search = search.Replace("%[", "[");
                        search = search.Replace("]%", "]");

                        foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                        {
                            if (match.Success == true)
                            {
                                Index = match.Index;
                                break;
                            }
                        }
                    }

                    else //Match characters in the %%
                    {
                        if (search.Length > 1)
                        {
                            search = search.Remove(0, 1);
                            search = search.Remove(search.Length - 1, 1);
                        }

                        search = search.Replace("%", "");

                        if (search.Contains("_")) //Single Character
                        {
                            search = search.Replace("_", ".");
                            foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                            {
                                Index = match.Index;
                                break;
                            }
                        }
                        else
                        {
                            foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                            {
                                Index = match.Index;
                                break;
                            }
                        }
                    }
                }

                else if (search.EndsWith("]")) //Match last any single character within the brackets
                {
                    search = search.Remove(0, 1);

                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        if (match.Success == true)
                        {
                            Index = match.Index;
                            break;
                        }
                    }
                }

                else if ((search.EndsWith("]") != true) & (search.EndsWith("%") != true))
                {
                    search = search + "$";
                    search = search.Remove(0, 1);
                    search = search.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        Index = match.Index;
                        break;
                    }
                }

                else
                {
                    search = search.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        Index = match.Index;
                        break;
                    }
                }
            }

            else if (search.StartsWith("["))
            {
                if (search.EndsWith("%"))
                {
                    search = "\b" + search;
                    search = search.Remove(search.Length - 1, 1);

                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        Index = match.Index;
                        break;
                    }
                }

                else if (search.EndsWith("]"))
                {
                    if (input.Length == 1)
                    {
                        foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                        {
                            Index = match.Index;
                            break;
                        }
                    }
                    else
                    {
                        Index = -1;
                    }
                }

                else
                {
                    search = "\b" + search + "\b";
                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        Index = match.Index;
                        break;
                    }
                }
            }

            else if ((search.StartsWith("[") != true) & (search.StartsWith("%") != true))
            {
                if ((search.Contains("_")) & (input.Length != 1))
                {
                    search = search.Replace("_", ".");
                }

                if (search.EndsWith("%"))
                {
                    search = "^" + search;
                    search = search.Remove(search.Length - 1);
                    search = search.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                    {
                        Index = match.Index;
                        break;
                    }
                }

                else
                {
                    if (search == input)
                    {
                        foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                        {
                            Index = match.Index;
                            break;
                        }
                    }

                    else if ((input.Length == 1) & (search == "_"))
                    {
                        Index = 0;
                    }

                    else if ((input.Length != 1) & (search != input))
                    {
                        if ((search == ".") & (input.Length > 1))
                        {
                            Index = -1;
                        }
                        else
                        {
                            foreach (Match match in Regex.Matches(input, search, RegexOptions.IgnoreCase))
                            {
                                Index = match.Index;
                                break;
                            }
                        }
                    }

                    else
                    {
                        Index = -1;
                    }
                }
            }

            return Index;

        }

        public T IsNull<T>(T input, T replacement)
        {
            if (input is IUDDTType uddtInput)
                return uddtInput.Value == null ? replacement : input;
            return input == null ? replacement : input;
        }

        public int IsNumeric<T>(T input)
        {
            object objInput = input;

            if (input is IUDDTType uDDTType)
                objInput = uDDTType.Value;

            string inputValue = ConvertObjectToString(objInput);

            return Decimal.TryParse(inputValue?.ToString(), System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal retNum) == true ? 1 : 0;
        }

        public bool In<T>(T input, object[] collection)
        {
            object objInput = input;

            if (input is IUDDTType uDDTType)
                objInput = uDDTType.Value;

            string inputValue = ConvertObjectToString(objInput);

            List<string> collectionValue = new List<string>();
            if (collection is IUDDTType[])
            {

                foreach (var item in collection)
                {
                    collectionValue.Add((string)ChangeType(((IUDDTType)item).Value, typeof(string)));
                }

                return collectionValue.Contains(inputValue);

            }

            return collection.Contains(objInput);
        }

        public bool NotIn<T>(T input, object[] collection)
        {
            object objInput = input;

            if (input is IUDDTType uDDTType)
                objInput = uDDTType.Value;


            string inputValue = ConvertObjectToString(objInput);

            List<string> collectionValue = new List<string>();
            if (collection is IUDDTType[])
            {

                foreach (var item in collection)
                {
                    collectionValue.Add((string)ChangeType(((IUDDTType)item).Value, typeof(string)));
                }

                return !collectionValue.Contains(inputValue);

            }

            return !collection.Contains(objInput);
        }

        public bool Like(string input, string pattern, bool notDefined = false, bool odbcEscape = false, string escapeExpression = "")
        {
            bool isMatch = false;

            if (escapeExpression != "")
            {
                pattern = pattern.Replace(escapeExpression, Regex.Escape(escapeExpression));
            }

            if (pattern.StartsWith("%")) //More characters before
            {
                if (pattern.EndsWith("%")) //More characters after
                {
                    if ((pattern.StartsWith("%[")) && (pattern.EndsWith("]%"))) //Match any single character within the brackets
                    {
                        pattern = pattern.Replace("%[", "[");
                        pattern = pattern.Replace("]%", "]");

                        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                        {
                            isMatch = match.Success;
                            break;
                        }
                    }

                    else //Match characters in the %%
                    {
                        if (pattern.Length > 1)
                        {
                            pattern = pattern.Remove(0, 1);
                            pattern = pattern.Remove(pattern.Length - 1, 1);
                        }

                        pattern = pattern.Replace("%", ".*");

                        if ((pattern.Contains("_")) & (escapeExpression != "_")) //Single Character
                        {
                            pattern = pattern.Replace("_", ".");
                            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                            {
                                isMatch = match.Success;
                                break;
                            }
                        }
                        else
                        {
                            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                            {
                                isMatch = match.Success;
                                break;
                            }
                        }
                    }
                }

                else if (pattern.EndsWith("]")) //Match last any single character within the brackets
                {
                    pattern = pattern.Remove(0, 1);

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }

                else if ((pattern.EndsWith("]") != true) & (pattern.EndsWith("%") != true))
                {
                    pattern = pattern + "$";
                    pattern = pattern.Remove(0, 1);
                    pattern = pattern.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }

                else
                {
                    pattern = pattern.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }
            }

            else if (pattern.StartsWith("["))
            {
                if (pattern.EndsWith("%"))
                {
                    pattern = "\b" + pattern;
                    pattern = pattern.Remove(pattern.Length - 1, 1);

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }

                else if (pattern.EndsWith("]"))
                {
                    if (input.Length == 1)
                    {
                        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                        {
                            isMatch = match.Success;
                            break;
                        }
                    }
                    else
                    {
                        isMatch = false;
                    }
                }

                else
                {
                    pattern = "\b" + pattern + "\b";

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }
            }

            else if ((pattern.StartsWith("[") != true) & (pattern.StartsWith("%") != true))
            {
                if ((pattern.Contains("_")) & (escapeExpression != "_") & (input.Length != 1))//Single Character
                {
                    pattern = pattern.Replace("_", ".");
                }

                if (pattern.EndsWith("%"))
                {
                    pattern = "^" + pattern;
                    pattern = pattern.Remove(pattern.Length - 1);
                    pattern = pattern.Replace("%", ".*");

                    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                    {
                        isMatch = match.Success;
                        break;
                    }
                }

                else
                {
                    if (pattern == input)
                    {
                        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                        {
                            isMatch = match.Success;
                            break;
                        }
                    }

                    else if ((input.Length == 1) & (pattern == "_"))
                    {
                        isMatch = true;
                    }

                    else if ((input.Length != 1) & (pattern != input))
                    {
                        if ((pattern == ".") & (input.Length > 1))
                        {
                            isMatch = false;
                        }

                        else
                        {
                            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                            {
                                isMatch = match.Success;
                                break;
                            }
                        }
                    }

                    else
                    {
                        isMatch = false;
                    }
                }
            }

            if (isMatch != notDefined)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public T Coalesce<T>(params object[] input)
        {
            foreach (var obj in input)
            {
                var objNew = obj;
                if (objNew is IUDDTType uDDTType)
                    objNew = uDDTType.Value;
                    if (objNew != null)
                {
                    if (objNew is T) return (T)objNew;
                    return (T)ChangeType(objNew, typeof(T));
                }
            }

            return (T)ChangeType(null, typeof(T));
        }

        public string Substring<T>(T input, int? start, int? length)
        {
            object objInput = input;
            if (input is IUDDTType uDDTType)
                objInput = uDDTType.Value;

            string inputValue = ConvertObjectToString(objInput);

            if (!start.HasValue && !length.HasValue)
            {
                return string.Empty;
            }
            else if (inputValue is null)
            {
                return null;
                //throw new Exception("Argument data type NULL is invalid for argument 1 of substring function.");
            }
            else
            {
                var newStart = start.HasValue ? start.Value - 1 : 0;
                var newLength = length.HasValue ? length.Value : 0;

                if (newStart < 1)
                {
                    try
                    {
                        return inputValue.Substring(0, (newLength + newStart));
                    }
                    catch (Exception)
                    {
                        return inputValue.Substring(0, inputValue.Count());
                    }
                }

                else if (newStart > inputValue.Count())
                {
                    return string.Empty;
                }

                else if (newLength < 0)
                {
                    throw new Exception("Invalid length parameter passed to the substring function.");
                }
                else if (newLength + newStart > inputValue.Count())
                {
                    return inputValue.Substring(newStart, inputValue.Count() - newStart);
                }
                else
                {
                    return inputValue.Substring(newStart, newLength);
                }
            }
        }

        public string Replace<T>(T input, string search, string replace)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;

            if (objInput == null || search == null || replace == null)
                return null;

            if (objInput is IUDDTType)
            {
                var value = ((IUDDTType)objInput).Value;

                return Convert.ToString(value).Replace(search, replace);
            }
            else
            {
                return Convert.ToString(objInput).Replace(search, replace);
            }
        }

        public Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName, false, true);
                if (type != null)
                    return type;
            }
            return null;
        }

        public string Format<T>(T input, object style)
        {
            /*
             * Limitation: Format will not throw an exception if any of the parameters is null.
             * Since the scenario of a null being an input instead of variable is highly unlikely to happen.
             * Examples: 
             * stringUtil.Format(null, null); => will return null instead of an sql exception message.
             * stringUtil.Format(null, style); => will return null instead of an sql exception message.
             * stringUtil.Format(input, null); => will return null instead of an sql exception message.
             */

            //Checks Input
            object objInput = input;

            if (objInput is IUDDTType inputUDDT)
            {
                if (inputUDDT.Value is null)
                    return null;
                else
                    objInput = inputUDDT.Value;
            }
            else
                //For native type
                if (objInput is null) return null;

            //Checks Style
            if (style is IUDDTType styleUDDT)
            {
                if (styleUDDT.Value is null)
                    return null;
                else
                    style = styleUDDT.Value;
            }
            else
                //For native type
                if (style is null) return null;

            // Replace pound sign to zero for string format
            string styleValue = $"{{0:{style.ToString().Replace("#", "0")}}}";

            string result = string.Format(styleValue, objInput);

            return result;
        }

        public string Format<T>(T input, object style, object cultureInfo)
        {
            /*
             * Limitation: Format will not throw an exception if any of the parameters is null.
             * Since the scenario of a null being an input instead of variable is highly unlikely to happen.
             * Examples: 
             * stringUtil.Format(null, null); => will return null instead of an sql exception message.
             * stringUtil.Format(null, style); => will return null instead of an sql exception message.
             * stringUtil.Format(input, null); => will return null instead of an sql exception message.
             */

            //Checks Input
            object objInput = input;

            if (objInput is IUDDTType inputUDDT)
            {
                if (inputUDDT.Value is null)
                    return null;
                else
                    objInput = inputUDDT.Value;
            }
            else
                //For native type
                if (objInput is null) return null;

            //Checks Style
            if (style is IUDDTType styleUDDT)
            {
                if (styleUDDT.Value is null)
                    return null;
                else
                    style = styleUDDT.Value;
            }
            else
                //For native type
                if (style is null) return null;

            if (cultureInfo is IUDDTType cultureInfoUDDT)
            {
                if (cultureInfoUDDT.Value is null)
                    cultureInfo = "en-US";
                else
                    cultureInfo = cultureInfoUDDT.Value;
            }
            else
                 //For native type
                 if (cultureInfo is null) cultureInfo = "en-US";

            // Replace pound sign to zero for string format
            string styleValue = $"{{0:{style.ToString().Replace("#", "0")}}}";

            //check if date
            var value = objInput.ToString();
            var culture = new CultureInfo(cultureInfo.ToString());
            if (DateTime.TryParse(value, out DateTime dateTime))
                return dateTime.ToString(style.ToString(), culture);
            else
                return string.Format(culture, styleValue, objInput);
        }

        public string RTrim<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            return ConvertObjectToString(objInput).TrimEnd();
        }

        public string LTrim<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            return ConvertObjectToString(objInput).TrimStart();
        }

        public string Trim<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            return ConvertObjectToString(objInput).Trim();
        }

        public string Upper<T>(T input)
        {
            object objInput = input;


            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            return ConvertObjectToString(objInput).ToUpper();
        }

        public string Lower<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            return ConvertObjectToString(objInput).ToLower();
        }

        public int? DataLength<T>(T input)
        {
            object objInput = input;

            if (objInput is IUDDTType uDDTType)
                objInput = uDDTType.Value;
            if (objInput is null) return null;

            string inputValue = ConvertObjectToString(objInput);

            // Multiplied by two since the result in SQL is double of length of the string 
            return inputValue.Length * 2;
        }
        public string Concat(params object[] multipleStrings)
        {
            if (multipleStrings == null
                || multipleStrings.Length <= 1) return null;
            string concatString = this.Concat(multipleStrings[0], multipleStrings[1]);
            for (int i = 2; i < multipleStrings.Length; i++)
            {
                concatString = this.Concat(concatString, multipleStrings[i]);
                if (concatString == null) return null;
            }
            return concatString;
        }
        private string Concat(object firstString, object secondString)
        {
            if (firstString == null) return null;
            if (secondString == null) return null;

            if (firstString is IUDDTType firstUDDTType)
                firstString = firstUDDTType.Value;
            if (secondString is IUDDTType secondUDDTType)
                secondString = secondUDDTType.Value;

            return firstString.ToString() + secondString.ToString();
        }

        public string Space<T>(T length)
        {
            object objLength = length;


            if (objLength is IUDDTType uDDTType)
                objLength = uDDTType.Value;
            if (objLength == null) return null;

            return new string(' ', Convert.ToInt32(objLength));
        }

        /// <summary>
        /// Convert Object to String Value for Native Type and UDDT 
        /// </summary>
        private string ConvertObjectToString(object input)
        {

            if (input is IUDDTType uDDTType)
                input = uDDTType.Value;

            string inputValue = string.Empty;
            if (input is IUDDTType)
                inputValue = (string)ChangeType(((IUDDTType)input).Value, typeof(string));
            else
                inputValue = (string)ChangeType(input, typeof(string));

            return inputValue;
        }

        private object ChangeType(object value, Type conversion)
        {

            if (value is IUDDTType uDDTType)
                value = uDDTType.Value;

            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }
            var inputValueType = value?.GetType();
            if (inputValueType == conversion) return value;

            var fullName = value?.GetType().FullName;
            if (fullName != null && (t.FullName.Contains("CSI.Data.SQL.UDDT")
                                     && fullName.Contains("CSI.Data.SQL.UDDT") == false))
            {
                foreach (var constructorInfo in conversion.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                {
                    try
                    {
                        return constructorInfo.Invoke(new object[] { value });
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            if (value != null && (value.GetType() == typeof(String) && conversion == typeof(Char)))
            {
                string stringValue = (string)value;

                if (int.TryParse(stringValue, out _))
                {
                    if (char.IsDigit(stringValue[stringValue.Length - 1]))
                        return stringValue[stringValue.Length - 1];
                    else
                        return stringValue[0];
                }
            }

            if (conversion == typeof(Guid))
                return Guid.Parse(value as string);

            if (value is string stringEmptyValue && t == typeof(DateTime))
            {
                if (stringEmptyValue == "")
                    return DateTime.Parse("1900-01-01 00:00:00.000");
                return DateTime.Parse(stringEmptyValue);
            }
            return Convert.ChangeType(value, t);
        }


    }
}
