//PROJECT NAME: DataCollection
//CLASS NAME: DcjrSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjrSerialSaveFactory
	{
		public IDcjrSerialSave Create(IApplicationDB appDB)
		{
			var _DcjrSerialSave = new DataCollection.DcjrSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjrSerialSaveExt = timerfactory.Create<DataCollection.IDcjrSerialSave>(_DcjrSerialSave);
			
			return iDcjrSerialSaveExt;
		}
	}
}
