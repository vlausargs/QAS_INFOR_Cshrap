//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteTaxFreeImportsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class DeleteTaxFreeImportsFactory
	{
		public IDeleteTaxFreeImports Create(IApplicationDB appDB)
		{
			var _DeleteTaxFreeImports = new Material.DeleteTaxFreeImports(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTaxFreeImportsExt = timerfactory.Create<Material.IDeleteTaxFreeImports>(_DeleteTaxFreeImports);
			
			return iDeleteTaxFreeImportsExt;
		}
	}
}
