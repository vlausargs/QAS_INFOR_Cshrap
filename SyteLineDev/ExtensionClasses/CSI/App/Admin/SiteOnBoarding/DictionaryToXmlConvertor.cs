using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDictionaryToXmlConvertor
    {
        List<string> ConvertDictionaryToXml(string tableName, string appViewName, List<Dictionary<string, string>> records);
    }

    public class DictionaryToXmlConvertor : IDictionaryToXmlConvertor
    {
        public List<string> ConvertDictionaryToXml(string tableName, string appViewName, List<Dictionary<string, string>> records)
        {

            var xmlList = new List<string>();

            var r = new Dictionary<string, string>();

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Indent = false,
                NewLineChars = "",
                ConformanceLevel = ConformanceLevel.Fragment,
                OmitXmlDeclaration = false
            };

            foreach (var row in records)
            {
                r = row;
                using (var xmlWriter = XmlWriter.Create(builder, settings))
                {
                    xmlWriter.WriteStartElement(tableName);
                    var el = new XElement(
                        appViewName,
                        row.Select(kv => new XElement(XmlConvert.EncodeName(kv.Key), string.IsNullOrWhiteSpace(kv.Value) ? "null" : kv.Value)));
                    el.WriteTo(xmlWriter);
                    xmlWriter.WriteEndElement();
                }

                xmlList.Add(builder.ToString());
                builder.Clear();
                r = null;
            }

            return xmlList;
        }
    }
}