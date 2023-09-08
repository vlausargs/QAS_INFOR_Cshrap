//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctranDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctranDFactory
	{
		public IDctranD Create(IApplicationDB appDB)
		{
			var _DctranD = new DataCollection.DctranD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctranDExt = timerfactory.Create<DataCollection.IDctranD>(_DctranD);
			
			return iDctranDExt;
		}
	}
}
