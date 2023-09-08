using System.Collections.Generic;
using System.Xml.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface INullableForeignKeyHandler
    {
        object SetNullableForeignKeyToEmpty(
            XElement xElement,
            Dictionary<string, string> tableNullableForeignKey);
    }
}