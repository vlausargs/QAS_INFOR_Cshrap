//PROJECT NAME: Production
//CLASS NAME: ValidateEcnValForJobOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ValidateEcnValForJobOperFactory
	{
		public IValidateEcnValForJobOper Create(IApplicationDB appDB)
		{
			var _ValidateEcnValForJobOper = new Production.ValidateEcnValForJobOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateEcnValForJobOperExt = timerfactory.Create<Production.IValidateEcnValForJobOper>(_ValidateEcnValForJobOper);
			
			return iValidateEcnValForJobOperExt;
		}
	}
}
