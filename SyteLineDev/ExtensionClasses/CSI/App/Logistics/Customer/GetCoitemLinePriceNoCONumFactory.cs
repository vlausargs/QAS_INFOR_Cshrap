//PROJECT NAME: Logistics
//CLASS NAME: GetCoitemLinePriceNoCONumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCoitemLinePriceNoCONumFactory
	{
		public IGetCoitemLinePriceNoCONum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCoitemLinePriceNoCONum = new Logistics.Customer.GetCoitemLinePriceNoCONum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoitemLinePriceNoCONumExt = timerfactory.Create<Logistics.Customer.IGetCoitemLinePriceNoCONum>(_GetCoitemLinePriceNoCONum);
			
			return iGetCoitemLinePriceNoCONumExt;
		}
	}
}
