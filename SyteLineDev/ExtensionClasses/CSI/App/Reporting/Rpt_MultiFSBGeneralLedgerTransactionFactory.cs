//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
    public class Rpt_MultiFSBGeneralLedgerTransactionFactory
    {
        public IRpt_MultiFSBGeneralLedgerTransaction Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _Rpt_MultiFSBGeneralLedgerTransaction = new Reporting.Rpt_MultiFSBGeneralLedgerTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_MultiFSBGeneralLedgerTransactionExt = timerfactory.Create<Reporting.IRpt_MultiFSBGeneralLedgerTransaction>(_Rpt_MultiFSBGeneralLedgerTransaction);

            return iRpt_MultiFSBGeneralLedgerTransactionExt;
        }
    }
}
