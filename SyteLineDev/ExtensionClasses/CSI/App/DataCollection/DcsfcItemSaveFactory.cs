//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcItemSaveFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcItemSaveFactory
	{
		public IDcsfcItemSave Create(IApplicationDB appDB)
		{
			var _DcsfcItemSave = new DataCollection.DcsfcItemSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcItemSaveExt = timerfactory.Create<DataCollection.IDcsfcItemSave>(_DcsfcItemSave);
			
			return iDcsfcItemSaveExt;
		}
	}
}
