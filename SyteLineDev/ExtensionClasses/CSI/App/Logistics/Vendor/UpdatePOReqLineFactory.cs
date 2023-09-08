//PROJECT NAME: Logistics
//CLASS NAME: UpdatePOReqLineFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdatePOReqLineFactory
	{
		public IUpdatePOReqLine Create(IApplicationDB appDB)
		{
			var _UpdatePOReqLine = new Logistics.Vendor.UpdatePOReqLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePOReqLineExt = timerfactory.Create<Logistics.Vendor.IUpdatePOReqLine>(_UpdatePOReqLine);
			
			return iUpdatePOReqLineExt;
		}
	}
}
