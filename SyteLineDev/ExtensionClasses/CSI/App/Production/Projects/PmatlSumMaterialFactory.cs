//PROJECT NAME: Production
//CLASS NAME: PmatlSumMaterialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class PmatlSumMaterialFactory
	{
		public IPmatlSumMaterial Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PmatlSumMaterial = new Production.Projects.PmatlSumMaterial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmatlSumMaterialExt = timerfactory.Create<Production.Projects.IPmatlSumMaterial>(_PmatlSumMaterial);
			
			return iPmatlSumMaterialExt;
		}
	}
}
