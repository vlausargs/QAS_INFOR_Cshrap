//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjmDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjmDFactory
	{
		public IDcjmD Create(IApplicationDB appDB)
		{
			var _DcjmD = new DataCollection.DcjmD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjmDExt = timerfactory.Create<DataCollection.IDcjmD>(_DcjmD);
			
			return iDcjmDExt;
		}
	}
}
