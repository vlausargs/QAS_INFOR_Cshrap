//PROJECT NAME: CSIVendor
//CLASS NAME: GetNextVouchSeqFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetNextVouchSeqFactory
	{
		public IGetNextVouchSeq Create(IApplicationDB appDB)
		{
			var _GetNextVouchSeq = new Logistics.Vendor.GetNextVouchSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextVouchSeqExt = timerfactory.Create<Logistics.Vendor.IGetNextVouchSeq>(_GetNextVouchSeq);
			
			return iGetNextVouchSeqExt;
		}
	}
}
