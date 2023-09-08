using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public interface IXmlTextWriterUtil
    {
        void WriteStartElement(string localName, string ns);
        void WriteStartElement(string localName);
        void WriteAttributeString(string localName, string value);
        void WriteString(string text);
        void WriteEndElement();
        void Flush();
        void Close();

        string GetXMLString();
    }
}
