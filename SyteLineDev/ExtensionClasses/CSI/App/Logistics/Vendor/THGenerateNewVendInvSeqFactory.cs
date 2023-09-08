//PROJECT NAME: Logistics
//CLASS NAME: THGenerateNewVendInvSeqFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THGenerateNewVendInvSeqFactory
	{
		public ITHGenerateNewVendInvSeq Create(IApplicationDB appDB)
		{
			var _THGenerateNewVendInvSeq = new Logistics.Vendor.THGenerateNewVendInvSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHGenerateNewVendInvSeqExt = timerfactory.Create<Logistics.Vendor.ITHGenerateNewVendInvSeq>(_THGenerateNewVendInvSeq);
			
			return iTHGenerateNewVendInvSeqExt;
		}
	}
}
