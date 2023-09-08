//PROJECT NAME: Logistics
//CLASS NAME: EftFileCreateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class EftFileCreateFactory
	{
		public IEftFileCreate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EftFileCreate = new Logistics.Vendor.EftFileCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEftFileCreateExt = timerfactory.Create<Logistics.Vendor.IEftFileCreate>(_EftFileCreate);
			
			return iEftFileCreateExt;
		}
	}
}
