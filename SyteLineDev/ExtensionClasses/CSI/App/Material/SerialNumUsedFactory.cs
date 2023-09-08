//PROJECT NAME: Material
//CLASS NAME: SerialNumUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class SerialNumUsedFactory
	{
		public ISerialNumUsed Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SerialNumUsed = new Material.SerialNumUsed(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialNumUsedExt = timerfactory.Create<Material.ISerialNumUsed>(_SerialNumUsed);
			
			return iSerialNumUsedExt;
		}
	}
}
