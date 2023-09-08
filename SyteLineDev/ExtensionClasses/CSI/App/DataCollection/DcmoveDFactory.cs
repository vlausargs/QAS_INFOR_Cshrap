//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcmoveDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmoveDFactory
	{
		public IDcmoveD Create(IApplicationDB appDB)
		{
			var _DcmoveD = new DataCollection.DcmoveD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmoveDExt = timerfactory.Create<DataCollection.IDcmoveD>(_DcmoveD);
			
			return iDcmoveDExt;
		}
	}
}
