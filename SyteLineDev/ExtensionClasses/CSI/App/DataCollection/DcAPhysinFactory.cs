//PROJECT NAME: DataCollection
//CLASS NAME: DcAPhysinFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPhysinFactory
	{
		public IDcAPhysin Create(IApplicationDB appDB)
		{
			var _DcAPhysin = new DataCollection.DcAPhysin(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAPhysinExt = timerfactory.Create<DataCollection.IDcAPhysin>(_DcAPhysin);
			
			return iDcAPhysinExt;
		}
	}
}
