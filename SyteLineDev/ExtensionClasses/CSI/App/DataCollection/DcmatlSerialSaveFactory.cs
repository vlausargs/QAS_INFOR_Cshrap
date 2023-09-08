//PROJECT NAME: DataCollection
//CLASS NAME: DcmatlSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmatlSerialSaveFactory
	{
		public IDcmatlSerialSave Create(IApplicationDB appDB)
		{
			var _DcmatlSerialSave = new DataCollection.DcmatlSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmatlSerialSaveExt = timerfactory.Create<DataCollection.IDcmatlSerialSave>(_DcmatlSerialSave);
			
			return iDcmatlSerialSaveExt;
		}
	}
}
