using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowDateFactory : ILowDateFactory
    {
        public ILowDate Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _LowDate = new LowDate(appDB);


            return _LowDate;
        }
    }
}