//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcpoDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpoDFactory
	{
		public IDcpoD Create(IApplicationDB appDB)
		{
			var _DcpoD = new DataCollection.DcpoD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpoDExt = timerfactory.Create<DataCollection.IDcpoD>(_DcpoD);
			
			return iDcpoDExt;
		}
	}
}
