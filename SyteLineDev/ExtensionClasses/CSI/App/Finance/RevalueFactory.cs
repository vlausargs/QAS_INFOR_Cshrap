//PROJECT NAME: Finance
//CLASS NAME: RevalueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class RevalueFactory
	{
		public IRevalue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Revalue = new Finance.Revalue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRevalueExt = timerfactory.Create<Finance.IRevalue>(_Revalue);
			
			return iRevalueExt;
		}
	}
}
