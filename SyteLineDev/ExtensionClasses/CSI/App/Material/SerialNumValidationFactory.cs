//PROJECT NAME: Material
//CLASS NAME: SerialNumValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class SerialNumValidationFactory
	{
		public ISerialNumValidation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SerialNumValidation = new Material.SerialNumValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialNumValidationExt = timerfactory.Create<Material.ISerialNumValidation>(_SerialNumValidation);
			
			return iSerialNumValidationExt;
		}
	}
}
