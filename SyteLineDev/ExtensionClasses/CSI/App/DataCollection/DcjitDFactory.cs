//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjitDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitDFactory
	{
		public IDcjitD Create(IApplicationDB appDB)
		{
			var _DcjitD = new DataCollection.DcjitD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjitDExt = timerfactory.Create<DataCollection.IDcjitD>(_DcjitD);
			
			return iDcjitDExt;
		}
	}
}
