//PROJECT NAME: CSIDataCollection
//CLASS NAME: ChkSnFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class ChkSnFactory
	{
		public IChkSn Create(IApplicationDB appDB)
		{
			var _ChkSn = new DataCollection.ChkSn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkSnExt = timerfactory.Create<DataCollection.IChkSn>(_ChkSn);
			
			return iChkSnExt;
		}
	}
}
