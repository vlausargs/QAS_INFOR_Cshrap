//PROJECT NAME: Logistics
//CLASS NAME: MobileSROCreateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class MobileSROCreateFactory
	{
		public IMobileSROCreate Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _MobileSROCreate = new Logistics.FieldService.Partner.MobileSROCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMobileSROCreateExt = timerfactory.Create<Logistics.FieldService.Partner.IMobileSROCreate>(_MobileSROCreate);
			
			return iMobileSROCreateExt;
		}
	}
}
