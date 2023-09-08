//PROJECT NAME: DataCollection
//CLASS NAME: DcjitSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitSerialSaveFactory
	{
		public IDcjitSerialSave Create(IApplicationDB appDB)
		{
			var _DcjitSerialSave = new DataCollection.DcjitSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjitSerialSaveExt = timerfactory.Create<DataCollection.IDcjitSerialSave>(_DcjitSerialSave);
			
			return iDcjitSerialSaveExt;
		}
	}
}
