//PROJECT NAME: Finance
//CLASS NAME: GetAvailableParentFaNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class GetAvailableParentFaNumFactory
	{
		public IGetAvailableParentFaNum Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetAvailableParentFaNum = new Finance.GetAvailableParentFaNum(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAvailableParentFaNumExt = timerfactory.Create<Finance.IGetAvailableParentFaNum>(_GetAvailableParentFaNum);
			
			return iGetAvailableParentFaNumExt;
		}
	}
}
