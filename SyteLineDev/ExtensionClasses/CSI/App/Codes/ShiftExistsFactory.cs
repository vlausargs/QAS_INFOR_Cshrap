//PROJECT NAME: Codes
//CLASS NAME: ShiftExistsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class ShiftExistsFactory
	{
		public IShiftExists Create(IApplicationDB appDB)
		{
			var _ShiftExists = new Codes.ShiftExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShiftExistsExt = timerfactory.Create<Codes.IShiftExists>(_ShiftExists);
			
			return iShiftExistsExt;
		}
	}
}
