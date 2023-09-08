//PROJECT NAME: Adapters
//CLASS NAME: GetCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Adapters
{
    public class GetCodeFactory : IGetCodeFactory
    {
        public IGetCode Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetCode = new Adapters.GetCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCodeExt = timerfactory.Create<Adapters.IGetCode>(_GetCode);

            return iGetCodeExt;
        }

        public IGetCode Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetCode = new Adapters.GetCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCodeExt = timerfactory.Create<Adapters.IGetCode>(_GetCode);

            return iGetCodeExt;
        }
    }
}
