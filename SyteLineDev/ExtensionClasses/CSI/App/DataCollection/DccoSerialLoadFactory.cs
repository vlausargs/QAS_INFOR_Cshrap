//PROJECT NAME: CSIDataCollection
//CLASS NAME: DccoSerialLoadFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoSerialLoadFactory
	{
		public IDccoSerialLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _DccoSerialLoad = new DataCollection.DccoSerialLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccoSerialLoadExt = timerfactory.Create<DataCollection.IDccoSerialLoad>(_DccoSerialLoad);
			
			return iDccoSerialLoadExt;
		}
	}
}
