//PROJECT NAME: CSIDataCollection
//CLASS NAME: DccycDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DccycDFactory
	{
		public IDccycD Create(IApplicationDB appDB)
		{
			var _DccycD = new DataCollection.DccycD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccycDExt = timerfactory.Create<DataCollection.IDccycD>(_DccycD);
			
			return iDccycDExt;
		}
	}
}
