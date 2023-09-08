//PROJECT NAME: DataCollection
//CLASS NAME: DctrSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DctrSerialSaveFactory
	{
		public IDctrSerialSave Create(IApplicationDB appDB)
		{
			var _DctrSerialSave = new DataCollection.DctrSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctrSerialSaveExt = timerfactory.Create<DataCollection.IDctrSerialSave>(_DctrSerialSave);
			
			return iDctrSerialSaveExt;
		}
	}
}
