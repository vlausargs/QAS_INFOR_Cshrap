//PROJECT NAME: Material
//CLASS NAME: UpdateContainerItemSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class UpdateContainerItemSerialFactory
	{
		public IUpdateContainerItemSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateContainerItemSerial = new Material.UpdateContainerItemSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateContainerItemSerialExt = timerfactory.Create<Material.IUpdateContainerItemSerial>(_UpdateContainerItemSerial);
			
			return iUpdateContainerItemSerialExt;
		}
	}
}
