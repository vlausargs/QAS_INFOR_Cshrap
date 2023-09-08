//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcwcDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcwcDFactory
	{
		public IDcwcD Create(IApplicationDB appDB)
		{
			var _DcwcD = new DataCollection.DcwcD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcDExt = timerfactory.Create<DataCollection.IDcwcD>(_DcwcD);
			
			return iDcwcDExt;
		}
	}
}
