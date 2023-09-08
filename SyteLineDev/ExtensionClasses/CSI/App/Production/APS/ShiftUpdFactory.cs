//PROJECT NAME: Production
//CLASS NAME: ShiftUpdFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ShiftUpdFactory
	{
		public IShiftUpd Create(IApplicationDB appDB)
		{
			var _ShiftUpd = new Production.APS.ShiftUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShiftUpdExt = timerfactory.Create<Production.APS.IShiftUpd>(_ShiftUpd);
			
			return iShiftUpdExt;
		}
	}
}
