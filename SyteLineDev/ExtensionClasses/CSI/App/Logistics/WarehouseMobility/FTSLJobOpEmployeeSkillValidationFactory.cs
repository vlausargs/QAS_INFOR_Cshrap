//PROJECT NAME: Logistics
//CLASS NAME: FTSLJobOpEmployeeSkillValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLJobOpEmployeeSkillValidationFactory
	{
		public IFTSLJobOpEmployeeSkillValidation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLJobOpEmployeeSkillValidation = new Logistics.WarehouseMobility.FTSLJobOpEmployeeSkillValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLJobOpEmployeeSkillValidationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLJobOpEmployeeSkillValidation>(_FTSLJobOpEmployeeSkillValidation);
			
			return iFTSLJobOpEmployeeSkillValidationExt;
		}
	}
}
