//PROJECT NAME: Logistics
//CLASS NAME: APBalanceByPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
    public class APBalanceByPeriodFactory
    {
        public IAPBalanceByPeriod Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _APBalanceByPeriod = new Logistics.Vendor.APBalanceByPeriod(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPBalanceByPeriodExt = timerfactory.Create<Logistics.Vendor.IAPBalanceByPeriod>(_APBalanceByPeriod);

            return iAPBalanceByPeriodExt;
        }
    }
}