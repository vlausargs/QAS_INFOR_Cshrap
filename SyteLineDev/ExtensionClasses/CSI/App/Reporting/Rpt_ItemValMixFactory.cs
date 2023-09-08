//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemValMixFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
    public class Rpt_ItemValMixFactory
    {
        public IRpt_ItemValMix Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _Rpt_ItemValMix = new Reporting.Rpt_ItemValMix(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ItemValMixExt = timerfactory.Create<Reporting.IRpt_ItemValMix>(_Rpt_ItemValMix);

            return iRpt_ItemValMixExt;
        }
    }
}
