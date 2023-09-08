//PROJECT NAME: Production
//CLASS NAME: SchedpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class SchedpFactory
	{
		public ISchedp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Schedp = new Production.Schedp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedpExt = timerfactory.Create<Production.ISchedp>(_Schedp);
			
			return iSchedpExt;
		}
	}
}
