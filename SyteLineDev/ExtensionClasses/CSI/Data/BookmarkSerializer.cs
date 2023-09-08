using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System.Globalization;

namespace CSI.Data
{
    public class BookmarkSerializer : ICacheEntrySerializer
    {
        public ICachable Deserialize(string serialization)
        {
            Dictionary<string, object> dicRow = new Dictionary<string, object>();
            Dictionary<string, SortOrderDirection> dicSort = new Dictionary<string, SortOrderDirection>();
            Dictionary<string, object> defaultValueRow = new Dictionary<string, object>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(serialization);
            if (xmlDoc.ChildNodes.Count == 0)
            {
                return null;
            }

            foreach (XmlNode node in xmlDoc.ChildNodes[0].ChildNodes)
            {
                string column = node.Attributes[0].Value;
                string value = node.Attributes[1].Value;
                string direction = node.Attributes[2].Value;
                string defaultValue = node.Attributes[3].Value;

                dicRow.Add(column, value);
                defaultValueRow.Add(column, defaultValue);
                if (direction == "Ascending") dicSort.Add(column, SortOrderDirection.Ascending);
                else dicSort.Add(column, SortOrderDirection.Descending);
            }

            Record record = new Record(dicRow, null, new DataConverter());
            SortOrder sortOrder = new SortOrder(dicSort);

            Bookmark bookmark = new Bookmark(record, sortOrder, defaultValueRow);
            return bookmark;
        }

        public string Serialize(ICachable value)
        {
            Bookmark bookmark = (Bookmark)value;
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Bookmark");
            xmlDoc.AppendChild(rootElement);
            foreach (IBookmarkColumn column in bookmark.Columns)
            {
                XmlAttribute nameAttr = xmlDoc.CreateAttribute("Name");
                nameAttr.Value = column.Name;
                XmlAttribute valueAttr = xmlDoc.CreateAttribute("Value");
                if (column.Value is DateTime tempValue)
                    valueAttr.Value = tempValue.ToString("yyyy/MM/dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
                else
                    valueAttr.Value = Convert.ToString(column.Value);
                XmlAttribute dirAttr = xmlDoc.CreateAttribute("Direction");
                dirAttr.Value = Convert.ToString(column.Direction);

                XmlAttribute defValueAttr = xmlDoc.CreateAttribute("DefaultValue");
                if (column.DefaultValue != null)
                    defValueAttr.Value = Convert.ToString(column.DefaultValue);

                XmlElement itemElement = xmlDoc.CreateElement("Item");
                itemElement.Attributes.Append(nameAttr);
                itemElement.Attributes.Append(valueAttr);
                itemElement.Attributes.Append(dirAttr);
                itemElement.Attributes.Append(defValueAttr);
                rootElement.AppendChild(itemElement);
            }

            using (StringWriter stringWriter = new StringWriter())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlDoc.WriteTo(xmlTextWriter);
                string xmlText = stringWriter.ToString();
                return xmlText;
            }
        }
    }
}