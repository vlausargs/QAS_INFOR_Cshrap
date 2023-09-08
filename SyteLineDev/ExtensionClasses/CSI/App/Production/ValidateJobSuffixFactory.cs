//PROJECT NAME: Production
//CLASS NAME: ValidateJobSuffixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ValidateJobSuffixFactory
	{
		public IValidateJobSuffix Create(IApplicationDB appDB)
		{
			var _ValidateJobSuffix = new Production.ValidateJobSuffix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobSuffixExt = timerfactory.Create<Production.IValidateJobSuffix>(_ValidateJobSuffix);
			
			return iValidateJobSuffixExt;
		}
	}
}
