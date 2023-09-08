using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class DefinedValueBySessionIdFactory : IDefinedValueBySessionIdFactory
    {
        public IDefinedValueBySessionId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var _DefinedValueBySessionId = new DefinedValueBySessionId(appDB);
            return _DefinedValueBySessionId;
        }
    }
}
