using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public class NullableForeignKeyHandler : INullableForeignKeyHandler
    {
        public object SetNullableForeignKeyToEmpty(
            XElement xElement,
            Dictionary<string, string> tableNullableForeignKey)
        {
            // Normally attribute won't be empty, but to prevent columnName is null, set to empty default.
            var columnName = XmlConvert.DecodeName(xElement.Name.LocalName) ??
                             string.Empty;

            if (tableNullableForeignKey.ContainsKey(columnName))
            {
                return string.Empty;
            }

            return xElement.Name.LocalName == "RowPointer"
                ? Guid.Parse(xElement.Value)
                : string.Compare(xElement.Value, "null", true) == 0 ? null : (object)xElement.Value;
        }
    }
}