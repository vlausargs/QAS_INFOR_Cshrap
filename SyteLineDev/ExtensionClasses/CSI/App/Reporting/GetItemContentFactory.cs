//PROJECT NAME: Reporting
//CLASS NAME: GetItemContentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
    public class GetItemContentFactory
    {
        public IGetItemContent Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _GetItemContent = new Reporting.GetItemContent(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetItemContentExt = timerfactory.Create<Reporting.IGetItemContent>(_GetItemContent);

            return iGetItemContentExt;
        }
    }
}
