//PROJECT NAME: Production
//CLASS NAME: ShiftSaveFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ShiftSaveFactory
	{
		public IShiftSave Create(IApplicationDB appDB)
		{
			var _ShiftSave = new Production.ShiftSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShiftSaveExt = timerfactory.Create<Production.IShiftSave>(_ShiftSave);
			
			return iShiftSaveExt;
		}
	}
}
