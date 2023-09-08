//PROJECT NAME: Admin
//CLASS NAME: SumJourCheckFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SumJourCheckFactory
	{
		public ISumJourCheck Create(IApplicationDB appDB)
		{
			var _SumJourCheck = new Admin.SumJourCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSumJourCheckExt = timerfactory.Create<Admin.ISumJourCheck>(_SumJourCheck);
			
			return iSumJourCheckExt;
		}
	}
}
