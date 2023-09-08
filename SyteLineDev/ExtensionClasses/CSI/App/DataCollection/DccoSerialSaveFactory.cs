//PROJECT NAME: DataCollection
//CLASS NAME: DccoSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoSerialSaveFactory
	{
		public IDccoSerialSave Create(IApplicationDB appDB)
		{
			var _DccoSerialSave = new DataCollection.DccoSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccoSerialSaveExt = timerfactory.Create<DataCollection.IDccoSerialSave>(_DccoSerialSave);
			
			return iDccoSerialSaveExt;
		}
	}
}
