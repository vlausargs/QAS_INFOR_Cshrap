//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBItemSkillFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBItemSkillFactory
	{
		public ICLM_ESBItemSkill Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBItemSkill = new BusInterface.CLM_ESBItemSkill(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBItemSkillExt = timerfactory.Create<BusInterface.ICLM_ESBItemSkill>(_CLM_ESBItemSkill);
			
			return iCLM_ESBItemSkillExt;
		}
	}
}
