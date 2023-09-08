//PROJECT NAME: Production
//CLASS NAME: AU_CLM_QAProcessRefGetValueFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Automotive
{
	public class AU_CLM_QAProcessRefGetValueFactory
	{
		public IAU_CLM_QAProcessRefGetValue Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_CLM_QAProcessRefGetValue = new Production.Automotive.AU_CLM_QAProcessRefGetValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CLM_QAProcessRefGetValueExt = timerfactory.Create<Production.Automotive.IAU_CLM_QAProcessRefGetValue>(_AU_CLM_QAProcessRefGetValue);
			
			return iAU_CLM_QAProcessRefGetValueExt;
		}
	}
}
