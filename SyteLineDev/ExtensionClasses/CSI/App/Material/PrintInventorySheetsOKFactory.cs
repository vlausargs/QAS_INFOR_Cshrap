//PROJECT NAME: Material
//CLASS NAME: PrintInventorySheetsOKFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PrintInventorySheetsOKFactory
	{
		public IPrintInventorySheetsOK Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrintInventorySheetsOK = new Material.PrintInventorySheetsOK(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrintInventorySheetsOKExt = timerfactory.Create<Material.IPrintInventorySheetsOK>(_PrintInventorySheetsOK);
			
			return iPrintInventorySheetsOKExt;
		}
	}
}
