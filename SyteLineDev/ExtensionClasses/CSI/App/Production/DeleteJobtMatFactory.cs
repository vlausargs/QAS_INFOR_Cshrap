//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteJobtMatFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class DeleteJobtMatFactory
	{
		public IDeleteJobtMat Create(IApplicationDB appDB)
		{
			var _DeleteJobtMat = new Production.DeleteJobtMat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteJobtMatExt = timerfactory.Create<Production.IDeleteJobtMat>(_DeleteJobtMat);
			
			return iDeleteJobtMatExt;
		}
	}
}
