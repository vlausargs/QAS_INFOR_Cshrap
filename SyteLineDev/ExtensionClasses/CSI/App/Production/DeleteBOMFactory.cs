//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteBOMFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class DeleteBOMFactory
	{
		public IDeleteBOM Create(IApplicationDB appDB)
		{
			var _DeleteBOM = new Production.DeleteBOM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteBOMExt = timerfactory.Create<Production.IDeleteBOM>(_DeleteBOM);
			
			return iDeleteBOMExt;
		}
	}
}
