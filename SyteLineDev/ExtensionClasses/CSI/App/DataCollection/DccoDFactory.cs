//PROJECT NAME: CSIDataCollection
//CLASS NAME: DccoDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoDFactory
	{
		public IDccoD Create(IApplicationDB appDB)
		{
			var _DccoD = new DataCollection.DccoD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccoDExt = timerfactory.Create<DataCollection.IDccoD>(_DccoD);
			
			return iDccoDExt;
		}
	}
}
