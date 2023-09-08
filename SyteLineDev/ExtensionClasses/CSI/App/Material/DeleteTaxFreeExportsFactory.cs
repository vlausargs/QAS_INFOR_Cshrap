//PROJECT NAME: Material
//CLASS NAME: DeleteTaxFreeExportsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class DeleteTaxFreeExportsFactory
	{
		public IDeleteTaxFreeExports Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteTaxFreeExports = new Material.DeleteTaxFreeExports(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTaxFreeExportsExt = timerfactory.Create<Material.IDeleteTaxFreeExports>(_DeleteTaxFreeExports);
			
			return iDeleteTaxFreeExportsExt;
		}
	}
}
