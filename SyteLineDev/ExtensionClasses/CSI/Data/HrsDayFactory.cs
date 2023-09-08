//PROJECT NAME: Data
//CLASS NAME: HrsDayFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data
{
    public class HrsDayFactory
    {
        public IHrsDay Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _HrsDay = new Data.HrsDay(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHrsDayExt = timerfactory.Create<Data.IHrsDay>(_HrsDay);

            return iHrsDayExt;
        }
    }
}
