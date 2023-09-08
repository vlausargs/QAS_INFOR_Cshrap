using System.IO;
using System.Xml;

namespace CSI.Data.Utilities
{
    public class XmlTextWriterUtil : IXmlTextWriterUtil
    {
        readonly XmlTextWriter XmlTextWriter;
        readonly StringWriter StringWriter;
        public XmlTextWriterUtil()
        {
            this.StringWriter = new StringWriter();
            this.XmlTextWriter = new XmlTextWriter(StringWriter);
        }

        public void WriteStartElement(string localName, string ns)
        {
            this.XmlTextWriter.WriteStartElement(localName, ns);
        }

        public void WriteStartElement(string localName)
        {
            this.XmlTextWriter.WriteStartElement(localName);
        }

        public void WriteAttributeString(string localName, string value)
        {
            this.XmlTextWriter.WriteAttributeString(localName, value);
        }

        public void WriteString(string text)
        {
            this.XmlTextWriter.WriteString(text);
        }

        public void WriteEndElement()
        {
            this.XmlTextWriter.WriteEndElement();
        }
        public void Flush()
        {
            this.XmlTextWriter.Flush();
        }

        public void Close()
        {
            this.XmlTextWriter.Close();
        }

        public string GetXMLString()
        {
            return this.StringWriter.ToString();
        }

    }
}
