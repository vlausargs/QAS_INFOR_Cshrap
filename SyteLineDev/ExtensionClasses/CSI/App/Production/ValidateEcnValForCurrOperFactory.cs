//PROJECT NAME: Production
//CLASS NAME: ValidateEcnValForCurrOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ValidateEcnValForCurrOperFactory
	{
		public IValidateEcnValForCurrOper Create(IApplicationDB appDB)
		{
			var _ValidateEcnValForCurrOper = new Production.ValidateEcnValForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateEcnValForCurrOperExt = timerfactory.Create<Production.IValidateEcnValForCurrOper>(_ValidateEcnValForCurrOper);
			
			return iValidateEcnValForCurrOperExt;
		}
	}
}
