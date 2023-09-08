//PROJECT NAME: Logistics
//CLASS NAME: CiGenadFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CiGenadFactory
	{
		public ICiGenad Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CiGenad = new Logistics.Customer.CiGenad(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCiGenadExt = timerfactory.Create<Logistics.Customer.ICiGenad>(_CiGenad);
			
			return iCiGenadExt;
		}
	}
}
