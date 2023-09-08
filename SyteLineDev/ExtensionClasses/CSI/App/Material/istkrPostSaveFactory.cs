//PROJECT NAME: Material
//CLASS NAME: istkrPostSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class istkrPostSaveFactory
	{
		public IistkrPostSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _istkrPostSave = new Material.istkrPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrPostSaveExt = timerfactory.Create<Material.IistkrPostSave>(_istkrPostSave);
			
			return iistkrPostSaveExt;
		}
	}
}
