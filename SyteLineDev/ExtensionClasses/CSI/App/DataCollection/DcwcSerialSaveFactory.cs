//PROJECT NAME: DataCollection
//CLASS NAME: DcwcSerialSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcwcSerialSaveFactory
	{
		public IDcwcSerialSave Create(IApplicationDB appDB)
		{
			var _DcwcSerialSave = new DataCollection.DcwcSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcSerialSaveExt = timerfactory.Create<DataCollection.IDcwcSerialSave>(_DcwcSerialSave);
			
			return iDcwcSerialSaveExt;
		}
	}
}
