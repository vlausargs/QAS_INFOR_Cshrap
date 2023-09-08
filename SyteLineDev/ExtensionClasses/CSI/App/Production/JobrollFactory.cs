//PROJECT NAME: Production
//CLASS NAME: JobrollFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class JobrollFactory
	{
		public IJobroll Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Jobroll = new Production.Jobroll(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobrollExt = timerfactory.Create<Production.IJobroll>(_Jobroll);
			
			return iJobrollExt;
		}
	}
}
