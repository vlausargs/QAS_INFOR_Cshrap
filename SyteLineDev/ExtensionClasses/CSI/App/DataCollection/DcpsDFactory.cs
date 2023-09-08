//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcpsDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpsDFactory
	{
		public IDcpsD Create(IApplicationDB appDB)
		{
			var _DcpsD = new DataCollection.DcpsD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpsDExt = timerfactory.Create<DataCollection.IDcpsD>(_DcpsD);
			
			return iDcpsDExt;
		}
	}
}
