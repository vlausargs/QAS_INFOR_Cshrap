//PROJECT NAME: CSIVendor
//CLASS NAME: DeletePoRequisitionLinesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DeletePoRequisitionLinesFactory
	{
		public IDeletePoRequisitionLines Create(IApplicationDB appDB)
		{
			var _DeletePoRequisitionLines = new Logistics.Vendor.DeletePoRequisitionLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeletePoRequisitionLinesExt = timerfactory.Create<Logistics.Vendor.IDeletePoRequisitionLines>(_DeletePoRequisitionLines);
			
			return iDeletePoRequisitionLinesExt;
		}
	}
}
