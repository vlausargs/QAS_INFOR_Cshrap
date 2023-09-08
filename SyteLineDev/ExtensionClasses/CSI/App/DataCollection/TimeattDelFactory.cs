//PROJECT NAME: DataCollection
//CLASS NAME: TimeattDelFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class TimeattDelFactory
	{
		public ITimeattDel Create(IApplicationDB appDB)
		{
			var _TimeattDel = new DataCollection.TimeattDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTimeattDelExt = timerfactory.Create<DataCollection.ITimeattDel>(_TimeattDel);
			
			return iTimeattDelExt;
		}
	}
}
