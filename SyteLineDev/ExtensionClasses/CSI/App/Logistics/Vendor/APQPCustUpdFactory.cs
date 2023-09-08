//PROJECT NAME: Logistics
//CLASS NAME: APQPCustUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class APQPCustUpdFactory
	{
		public IAPQPCustUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _APQPCustUpd = new Logistics.Vendor.APQPCustUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPQPCustUpdExt = timerfactory.Create<Logistics.Vendor.IAPQPCustUpd>(_APQPCustUpd);
			
			return iAPQPCustUpdExt;
		}
	}
}
