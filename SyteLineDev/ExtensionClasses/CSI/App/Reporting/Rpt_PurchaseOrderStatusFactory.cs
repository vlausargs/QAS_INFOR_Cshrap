//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
    public class Rpt_PurchaseOrderStatusFactory
    {
        public IRpt_PurchaseOrderStatus Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _Rpt_PurchaseOrderStatus = new Reporting.Rpt_PurchaseOrderStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_PurchaseOrderStatusExt = timerfactory.Create<Reporting.IRpt_PurchaseOrderStatus>(_Rpt_PurchaseOrderStatus);

            return iRpt_PurchaseOrderStatusExt;
        }
    }
}