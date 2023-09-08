//PROJECT NAME: Material
//CLASS NAME: CheckTaxFreeMatlItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CheckTaxFreeMatlItemFactory
	{
		public ICheckTaxFreeMatlItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckTaxFreeMatlItem = new Material.CheckTaxFreeMatlItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckTaxFreeMatlItemExt = timerfactory.Create<Material.ICheckTaxFreeMatlItem>(_CheckTaxFreeMatlItem);
			
			return iCheckTaxFreeMatlItemExt;
		}
	}
}
