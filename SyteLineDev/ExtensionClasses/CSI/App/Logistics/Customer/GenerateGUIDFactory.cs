//PROJECT NAME: Logistics
//CLASS NAME: GenerateGUIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GenerateGUIDFactory
	{
		public IGenerateGUID Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenerateGUID = new Logistics.Customer.GenerateGUID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateGUIDExt = timerfactory.Create<Logistics.Customer.IGenerateGUID>(_GenerateGUID);
			
			return iGenerateGUIDExt;
		}
	}
}
