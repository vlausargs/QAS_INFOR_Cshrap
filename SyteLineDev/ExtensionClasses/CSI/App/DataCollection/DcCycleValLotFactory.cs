//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcCycleValLotFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcCycleValLotFactory
	{
		public IDcCycleValLot Create(IApplicationDB appDB)
		{
			var _DcCycleValLot = new DataCollection.DcCycleValLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcCycleValLotExt = timerfactory.Create<DataCollection.IDcCycleValLot>(_DcCycleValLot);
			
			return iDcCycleValLotExt;
		}
	}
}
