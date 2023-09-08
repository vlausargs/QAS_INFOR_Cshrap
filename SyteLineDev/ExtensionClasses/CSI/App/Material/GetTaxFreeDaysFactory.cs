//PROJECT NAME: Material
//CLASS NAME: GetTaxFreeDaysFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetTaxFreeDaysFactory
	{
		public IGetTaxFreeDays Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetTaxFreeDays = new Material.GetTaxFreeDays(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTaxFreeDaysExt = timerfactory.Create<Material.IGetTaxFreeDays>(_GetTaxFreeDays);
			
			return iGetTaxFreeDaysExt;
		}
	}
}
