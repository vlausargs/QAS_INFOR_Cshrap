//PROJECT NAME: Finance
//CLASS NAME: MultiFSBVerifyStartDateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBVerifyStartDateFactory
	{
		public IMultiFSBVerifyStartDate Create(IApplicationDB appDB)
		{
			var _MultiFSBVerifyStartDate = new Finance.MultiFSBVerifyStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBVerifyStartDateExt = timerfactory.Create<Finance.IMultiFSBVerifyStartDate>(_MultiFSBVerifyStartDate);
			
			return iMultiFSBVerifyStartDateExt;
		}
	}
}
