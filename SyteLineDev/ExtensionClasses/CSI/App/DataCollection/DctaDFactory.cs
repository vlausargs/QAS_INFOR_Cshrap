//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctaDFactory
	{
		public IDctaD Create(IApplicationDB appDB)
		{
			var _DctaD = new DataCollection.DctaD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctaDExt = timerfactory.Create<DataCollection.IDctaD>(_DctaD);
			
			return iDctaDExt;
		}
	}
}
