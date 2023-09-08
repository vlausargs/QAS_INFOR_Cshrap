//PROJECT NAME: Production
//CLASS NAME: AU_CLM_QAProcessSourceGetValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Automotive
{
	public class AU_CLM_QAProcessSourceGetValueFactory
	{
		public IAU_CLM_QAProcessSourceGetValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_CLM_QAProcessSourceGetValue = new Production.Automotive.AU_CLM_QAProcessSourceGetValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CLM_QAProcessSourceGetValueExt = timerfactory.Create<Production.Automotive.IAU_CLM_QAProcessSourceGetValue>(_AU_CLM_QAProcessSourceGetValue);
			
			return iAU_CLM_QAProcessSourceGetValueExt;
		}
	}
}
