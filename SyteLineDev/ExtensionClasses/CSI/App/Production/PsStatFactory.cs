//PROJECT NAME: Production
//CLASS NAME: PsStatFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class PsStatFactory
	{
		public IPsStat Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PsStat = new Production.PsStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsStatExt = timerfactory.Create<Production.IPsStat>(_PsStat);
			
			return iPsStatExt;
		}
	}
}
