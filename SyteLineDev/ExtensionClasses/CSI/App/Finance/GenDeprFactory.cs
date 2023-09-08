//PROJECT NAME: CSIFinance
//CLASS NAME: GenDeprFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GenDeprFactory
	{
		public IGenDepr Create(IApplicationDB appDB)
		{
			var _GenDepr = new Finance.GenDepr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenDeprExt = timerfactory.Create<Finance.IGenDepr>(_GenDepr);
			
			return iGenDeprExt;
		}
	}
}
