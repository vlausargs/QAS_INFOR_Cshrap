//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcSerialSaveFactory
	{
		public IDcsfcSerialSave Create(IApplicationDB appDB)
		{
			var _DcsfcSerialSave = new DataCollection.DcsfcSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcSerialSaveExt = timerfactory.Create<DataCollection.IDcsfcSerialSave>(_DcsfcSerialSave);
			
			return iDcsfcSerialSaveExt;
		}
	}
}
