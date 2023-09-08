//PROJECT NAME: NonTrans
//CLASS NAME: DeleteAlternativeFactory.cs

using CSI.MG;

namespace CSI.NonTrans
{
	public class DeleteAlternativeFactory
	{
		public IDeleteAlternative Create(IApplicationDB appDB)
		{
			var _DeleteAlternative = new NonTrans.DeleteAlternative(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteAlternativeExt = timerfactory.Create<NonTrans.IDeleteAlternative>(_DeleteAlternative);
			
			return iDeleteAlternativeExt;
		}
	}
}
