//PROJECT NAME: Finance
//CLASS NAME: UpdateUnitToDeprFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class UpdateUnitToDeprFactory
	{
		public IUpdateUnitToDepr Create(IApplicationDB appDB)
		{
			var _UpdateUnitToDepr = new Finance.UpdateUnitToDepr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateUnitToDeprExt = timerfactory.Create<Finance.IUpdateUnitToDepr>(_UpdateUnitToDepr);
			
			return iUpdateUnitToDeprExt;
		}
	}
}
