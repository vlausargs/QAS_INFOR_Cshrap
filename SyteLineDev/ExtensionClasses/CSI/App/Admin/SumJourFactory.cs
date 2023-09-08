//PROJECT NAME: Admin
//CLASS NAME: SumJourFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class SumJourFactory
	{
		public ISumJour Create(IApplicationDB appDB)
		{
			var _SumJour = new Admin.SumJour(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSumJourExt = timerfactory.Create<Admin.ISumJour>(_SumJour);
			
			return iSumJourExt;
		}
	}
}
