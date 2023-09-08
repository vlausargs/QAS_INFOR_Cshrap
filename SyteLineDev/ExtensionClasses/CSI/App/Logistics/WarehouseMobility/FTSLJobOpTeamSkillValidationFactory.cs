//PROJECT NAME: Logistics
//CLASS NAME: FTSLJobOpTeamSkillValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLJobOpTeamSkillValidationFactory
	{
		public IFTSLJobOpTeamSkillValidation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLJobOpTeamSkillValidation = new Logistics.WarehouseMobility.FTSLJobOpTeamSkillValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLJobOpTeamSkillValidationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLJobOpTeamSkillValidation>(_FTSLJobOpTeamSkillValidation);
			
			return iFTSLJobOpTeamSkillValidationExt;
		}
	}
}
