//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjrSerialLoadFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjrSerialLoadFactory
	{
		public IDcjrSerialLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _DcjrSerialLoad = new DataCollection.DcjrSerialLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjrSerialLoadExt = timerfactory.Create<DataCollection.IDcjrSerialLoad>(_DcjrSerialLoad);
			
			return iDcjrSerialLoadExt;
		}
	}
}
