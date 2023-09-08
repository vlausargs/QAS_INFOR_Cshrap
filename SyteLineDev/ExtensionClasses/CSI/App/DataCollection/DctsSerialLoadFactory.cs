//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctsSerialLoadFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctsSerialLoadFactory
	{
		public IDctsSerialLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _DctsSerialLoad = new DataCollection.DctsSerialLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctsSerialLoadExt = timerfactory.Create<DataCollection.IDctsSerialLoad>(_DctsSerialLoad);
			
			return iDctsSerialLoadExt;
		}
	}
}
