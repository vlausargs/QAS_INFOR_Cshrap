//PROJECT NAME: DataCollection
//CLASS NAME: DcjmSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjmSerialSaveFactory
	{
		public IDcjmSerialSave Create(IApplicationDB appDB)
		{
			var _DcjmSerialSave = new DataCollection.DcjmSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjmSerialSaveExt = timerfactory.Create<DataCollection.IDcjmSerialSave>(_DcjmSerialSave);
			
			return iDcjmSerialSaveExt;
		}
	}
}
