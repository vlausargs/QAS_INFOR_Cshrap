//PROJECT NAME: DataCollection
//CLASS NAME: DccycSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DccycSerialSaveFactory
	{
		public IDccycSerialSave Create(IApplicationDB appDB)
		{
			var _DccycSerialSave = new DataCollection.DccycSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccycSerialSaveExt = timerfactory.Create<DataCollection.IDccycSerialSave>(_DccycSerialSave);
			
			return iDccycSerialSaveExt;
		}
	}
}
