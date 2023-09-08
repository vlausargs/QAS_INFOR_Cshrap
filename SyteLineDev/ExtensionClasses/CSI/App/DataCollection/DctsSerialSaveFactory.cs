//PROJECT NAME: DataCollection
//CLASS NAME: DctsSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctsSerialSaveFactory
	{
		public IDctsSerialSave Create(IApplicationDB appDB)
		{
			var _DctsSerialSave = new DataCollection.DctsSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctsSerialSaveExt = timerfactory.Create<DataCollection.IDctsSerialSave>(_DctsSerialSave);
			
			return iDctsSerialSaveExt;
		}
	}
}
