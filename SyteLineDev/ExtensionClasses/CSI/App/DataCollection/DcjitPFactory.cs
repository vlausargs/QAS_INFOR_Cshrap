//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjitPFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitPFactory
	{
		public IDcjitP Create(IApplicationDB appDB)
		{
			var _DcjitP = new DataCollection.DcjitP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjitPExt = timerfactory.Create<DataCollection.IDcjitP>(_DcjitP);
			
			return iDcjitPExt;
		}
	}
}
