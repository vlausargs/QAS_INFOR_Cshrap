//PROJECT NAME: Material
//CLASS NAME: UpdatePreassignedSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class UpdatePreassignedSerialFactory
	{
		public IUpdatePreassignedSerial Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdatePreassignedSerial = new Material.UpdatePreassignedSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePreassignedSerialExt = timerfactory.Create<Material.IUpdatePreassignedSerial>(_UpdatePreassignedSerial);
			
			return iUpdatePreassignedSerialExt;
		}
	}
}
