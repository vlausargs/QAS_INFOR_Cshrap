//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcSyncQtyFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcSyncQtyFactory
	{
		public IDcSyncQty Create(IApplicationDB appDB)
		{
			var _DcSyncQty = new DataCollection.DcSyncQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcSyncQtyExt = timerfactory.Create<DataCollection.IDcSyncQty>(_DcSyncQty);
			
			return iDcSyncQtyExt;
		}
	}
}
