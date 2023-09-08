//PROJECT NAME: Finance
//CLASS NAME: VerifyEndDateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class VerifyEndDateFactory
	{
		public IVerifyEndDate Create(IApplicationDB appDB)
		{
			var _VerifyEndDate = new Finance.VerifyEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyEndDateExt = timerfactory.Create<Finance.IVerifyEndDate>(_VerifyEndDate);
			
			return iVerifyEndDateExt;
		}
	}
}
