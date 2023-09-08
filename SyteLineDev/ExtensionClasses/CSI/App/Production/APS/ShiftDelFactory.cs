//PROJECT NAME: Production
//CLASS NAME: ShiftDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ShiftDelFactory
	{
		public IShiftDel Create(IApplicationDB appDB)
		{
			var _ShiftDel = new Production.APS.ShiftDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShiftDelExt = timerfactory.Create<Production.APS.IShiftDel>(_ShiftDel);
			
			return iShiftDelExt;
		}
	}
}
