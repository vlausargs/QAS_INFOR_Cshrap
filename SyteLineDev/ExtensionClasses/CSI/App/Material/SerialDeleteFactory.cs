//PROJECT NAME: Material
//CLASS NAME: SerialDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class SerialDeleteFactory
	{
		public ISerialDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SerialDelete = new Material.SerialDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialDeleteExt = timerfactory.Create<Material.ISerialDelete>(_SerialDelete);
			
			return iSerialDeleteExt;
		}
	}
}
