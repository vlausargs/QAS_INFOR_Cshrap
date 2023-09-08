//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteShiftExceptionFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class DeleteShiftExceptionFactory
	{
		public IDeleteShiftException Create(IApplicationDB appDB)
		{
			var _DeleteShiftException = new Production.DeleteShiftException(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteShiftExceptionExt = timerfactory.Create<Production.IDeleteShiftException>(_DeleteShiftException);
			
			return iDeleteShiftExceptionExt;
		}
	}
}
