//PROJECT NAME: DataCollection
//CLASS NAME: DcpsSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcpsSerialSaveFactory
	{
		public IDcpsSerialSave Create(IApplicationDB appDB)
		{
			var _DcpsSerialSave = new DataCollection.DcpsSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpsSerialSaveExt = timerfactory.Create<DataCollection.IDcpsSerialSave>(_DcpsSerialSave);
			
			return iDcpsSerialSaveExt;
		}
	}
}
