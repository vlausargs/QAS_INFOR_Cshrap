//PROJECT NAME: Material
//CLASS NAME: PrintInventoryTagsOKFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PrintInventoryTagsOKFactory
	{
		public IPrintInventoryTagsOK Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrintInventoryTagsOK = new Material.PrintInventoryTagsOK(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrintInventoryTagsOKExt = timerfactory.Create<Material.IPrintInventoryTagsOK>(_PrintInventoryTagsOK);
			
			return iPrintInventoryTagsOKExt;
		}
	}
}
