//PROJECT NAME: DataCollection
//CLASS NAME: DcpoSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpoSerialSaveFactory
	{
		public IDcpoSerialSave Create(IApplicationDB appDB)
		{
			var _DcpoSerialSave = new DataCollection.DcpoSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpoSerialSaveExt = timerfactory.Create<DataCollection.IDcpoSerialSave>(_DcpoSerialSave);
			
			return iDcpoSerialSaveExt;
		}
	}
}
