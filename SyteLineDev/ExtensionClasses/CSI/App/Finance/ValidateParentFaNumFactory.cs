//PROJECT NAME: Finance
//CLASS NAME: ValidateParentFaNumFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ValidateParentFaNumFactory
	{
		public IValidateParentFaNum Create(IApplicationDB appDB)
		{
			var _ValidateParentFaNum = new Finance.ValidateParentFaNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateParentFaNumExt = timerfactory.Create<Finance.IValidateParentFaNum>(_ValidateParentFaNum);
			
			return iValidateParentFaNumExt;
		}
	}
}
