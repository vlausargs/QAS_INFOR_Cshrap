using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IByteArrayToListConvertor
    {
        List<List<string>> ConvertByteArrayToList(byte[] fileContent);
    }

    public class ByteArrayToListConvertor : IByteArrayToListConvertor
    {
        public ByteArrayToListConvertor()
        {
        }

        public List<List<string>> ConvertByteArrayToList(byte[] fileContent)
        {
            if (fileContent == null || fileContent.Length == 0) return new List<List<string>>();

            var fileContentString =
                System.Text.Encoding.UTF8.GetString(fileContent ?? Array.Empty<byte>());
            var stringSeparators = new[] {"\r\n"};
            var fileContentList = fileContentString
                .Split(stringSeparators, StringSplitOptions.None).ToList();

            // FIXME: Attention! 5000 is a magic number.
            return fileContentList
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index / 5000)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}