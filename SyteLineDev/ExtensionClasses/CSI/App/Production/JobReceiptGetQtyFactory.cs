//PROJECT NAME: CSIProduct
//CLASS NAME: JobReceiptGetQtyFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobReceiptGetQtyFactory
	{
		public IJobReceiptGetQty Create(IApplicationDB appDB)
		{
			var _JobReceiptGetQty = new Production.JobReceiptGetQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobReceiptGetQtyExt = timerfactory.Create<Production.IJobReceiptGetQty>(_JobReceiptGetQty);
			
			return iJobReceiptGetQtyExt;
		}
	}
}
