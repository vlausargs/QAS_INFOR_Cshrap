using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGIdoMetaData : IIDOMetaData
    {
        public string GetBaseTableFromIdoName(string idoName)
        {
            switch (idoName)
            {
                case "SLItems": return "item";
                default: throw new Exception($"Unknown IDO: {idoName}");
            }
        }
    }
}
