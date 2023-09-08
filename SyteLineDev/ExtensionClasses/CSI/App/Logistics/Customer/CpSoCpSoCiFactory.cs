//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoCiFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoCiFactory
	{
		public ICpSoCpSoCi Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CpSoCpSoCi = new Logistics.Customer.CpSoCpSoCi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpSoCpSoCiExt = timerfactory.Create<Logistics.Customer.ICpSoCpSoCi>(_CpSoCpSoCi);
			
			return iCpSoCpSoCiExt;
		}
	}
}
