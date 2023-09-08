//PROJECT NAME: Logistics
//CLASS NAME: CitemXPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CitemXPreFactory
	{
		public ICitemXPre Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CitemXPre = new Logistics.Customer.CitemXPre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCitemXPreExt = timerfactory.Create<Logistics.Customer.ICitemXPre>(_CitemXPre);
			
			return iCitemXPreExt;
		}
	}
}
