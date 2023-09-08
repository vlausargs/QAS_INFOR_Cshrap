//PROJECT NAME: Logistics.Customer
//CLASS NAME: Rpt_CashImpactSubFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
    public class Rpt_CashImpactSubFactory
    {
        public IRpt_CashImpactSub Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _Rpt_CashImpactSub = new Logistics.Customer.Rpt_CashImpactSub(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_CashImpactSubExt = timerfactory.Create<Logistics.Customer.IRpt_CashImpactSub>(_Rpt_CashImpactSub);

            return iRpt_CashImpactSubExt;
        }
    }
}
