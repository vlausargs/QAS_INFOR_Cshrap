//PROJECT NAME: Finance
//CLASS NAME: MultiFSBDateChkFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBDateChkFactory
	{
		public IMultiFSBDateChk Create(IApplicationDB appDB)
		{
			var _MultiFSBDateChk = new Finance.MultiFSBDateChk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBDateChkExt = timerfactory.Create<Finance.IMultiFSBDateChk>(_MultiFSBDateChk);
			
			return iMultiFSBDateChkExt;
		}
	}
}
