//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetWhseMatlFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetWhseMatlFactory
	{
		public ICLM_ApsGetWhseMatl Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetWhseMatl = new Production.APS.CLM_ApsGetWhseMatl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetWhseMatlExt = timerfactory.Create<Production.APS.ICLM_ApsGetWhseMatl>(_CLM_ApsGetWhseMatl);
			
			return iCLM_ApsGetWhseMatlExt;
		}
	}
}
