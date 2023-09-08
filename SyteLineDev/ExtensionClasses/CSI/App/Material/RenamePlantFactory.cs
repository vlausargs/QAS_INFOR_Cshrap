//PROJECT NAME: Material
//CLASS NAME: RenamePlantFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class RenamePlantFactory
	{
		public IRenamePlant Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _RenamePlant = new Material.RenamePlant(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRenamePlantExt = timerfactory.Create<Material.IRenamePlant>(_RenamePlant);
			
			return iRenamePlantExt;
		}
	}
}
