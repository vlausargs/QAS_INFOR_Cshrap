//PROJECT NAME: Production
//CLASS NAME: JoblowFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class JoblowFactory
	{
		public IJoblow Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Joblow = new Production.Joblow(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJoblowExt = timerfactory.Create<Production.IJoblow>(_Joblow);
			
			return iJoblowExt;
		}
	}
}
