//PROJECT NAME: Logistics
//CLASS NAME: GetCoitemSumOrderedQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCoitemSumOrderedQtyFactory
	{
		public IGetCoitemSumOrderedQty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCoitemSumOrderedQty = new Logistics.Customer.GetCoitemSumOrderedQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoitemSumOrderedQtyExt = timerfactory.Create<Logistics.Customer.IGetCoitemSumOrderedQty>(_GetCoitemSumOrderedQty);
			
			return iGetCoitemSumOrderedQtyExt;
		}
	}
}
