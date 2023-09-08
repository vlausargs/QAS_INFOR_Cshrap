//PROJECT NAME: Logistics
//CLASS NAME: CiGenPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CiGenPFactory
	{
		public ICiGenP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CiGenP = new Logistics.Customer.CiGenP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCiGenPExt = timerfactory.Create<Logistics.Customer.ICiGenP>(_CiGenP);
			
			return iCiGenPExt;
		}
	}
}
