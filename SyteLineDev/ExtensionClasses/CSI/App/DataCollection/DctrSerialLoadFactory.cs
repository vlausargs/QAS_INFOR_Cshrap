//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctrSerialLoadFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctrSerialLoadFactory
	{
		public IDctrSerialLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _DctrSerialLoad = new DataCollection.DctrSerialLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctrSerialLoadExt = timerfactory.Create<DataCollection.IDctrSerialLoad>(_DctrSerialLoad);
			
			return iDctrSerialLoadExt;
		}
	}
}
