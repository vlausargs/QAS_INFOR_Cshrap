//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadResourceSkillsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadResourceSkillsFactory
	{
		public ICLM_FTSLLoadResourceSkills Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadResourceSkills = new Logistics.WarehouseMobility.CLM_FTSLLoadResourceSkills(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadResourceSkillsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadResourceSkills>(_CLM_FTSLLoadResourceSkills);
			
			return iCLM_FTSLLoadResourceSkillsExt;
		}
	}
}
