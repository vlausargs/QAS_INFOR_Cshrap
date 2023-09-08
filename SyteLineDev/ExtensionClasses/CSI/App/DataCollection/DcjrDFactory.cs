//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjrDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjrDFactory
	{
		public IDcjrD Create(IApplicationDB appDB)
		{
			var _DcjrD = new DataCollection.DcjrD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjrDExt = timerfactory.Create<DataCollection.IDcjrD>(_DcjrD);
			
			return iDcjrDExt;
		}
	}
}
