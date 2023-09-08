using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetLabelFactory : IGetLabelFactory
    {
        public IGetLabel Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetLabel = new GetLabel(appDB);


            return _GetLabel;
        }
    }
}
