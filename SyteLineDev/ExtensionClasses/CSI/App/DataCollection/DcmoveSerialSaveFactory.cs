//PROJECT NAME: DataCollection
//CLASS NAME: DcmoveSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmoveSerialSaveFactory
	{
		public IDcmoveSerialSave Create(IApplicationDB appDB)
		{
			var _DcmoveSerialSave = new DataCollection.DcmoveSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmoveSerialSaveExt = timerfactory.Create<DataCollection.IDcmoveSerialSave>(_DcmoveSerialSave);
			
			return iDcmoveSerialSaveExt;
		}
	}
}
