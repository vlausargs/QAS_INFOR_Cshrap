//PROJECT NAME: Production
//CLASS NAME: ShiftExceptionFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ShiftExceptionFactory
	{
		public IShiftException Create(IApplicationDB appDB)
		{
			var _ShiftException = new Production.ShiftException(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShiftExceptionExt = timerfactory.Create<Production.IShiftException>(_ShiftException);
			
			return iShiftExceptionExt;
		}
	}
}
