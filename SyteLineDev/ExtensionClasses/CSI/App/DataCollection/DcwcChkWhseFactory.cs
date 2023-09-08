//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcwcChkWhseFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcwcChkWhseFactory
	{
		public IDcwcChkWhse Create(IApplicationDB appDB)
		{
			var _DcwcChkWhse = new DataCollection.DcwcChkWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcChkWhseExt = timerfactory.Create<DataCollection.IDcwcChkWhse>(_DcwcChkWhse);
			
			return iDcwcChkWhseExt;
		}
	}
}
