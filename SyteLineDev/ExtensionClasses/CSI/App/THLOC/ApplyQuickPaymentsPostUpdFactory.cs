//PROJECT NAME: THLOC
//CLASS NAME: ApplyQuickPaymentsPostUpdFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.THLOC
{
    public class ApplyQuickPaymentsPostUpdFactory
    {
        public IApplyQuickPaymentsPostUpd Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _ApplyQuickPaymentsPostUpd = new THLOC.ApplyQuickPaymentsPostUpd(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApplyQuickPaymentsPostUpdExt = timerfactory.Create<THLOC.IApplyQuickPaymentsPostUpd>(_ApplyQuickPaymentsPostUpd);

            return iApplyQuickPaymentsPostUpdExt;
        }
    }
}
