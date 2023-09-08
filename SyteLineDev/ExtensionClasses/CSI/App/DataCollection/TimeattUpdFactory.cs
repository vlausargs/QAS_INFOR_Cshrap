//PROJECT NAME: DataCollection
//CLASS NAME: TimeattUpdFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class TimeattUpdFactory
	{
		public ITimeattUpd Create(IApplicationDB appDB)
		{
			var _TimeattUpd = new DataCollection.TimeattUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTimeattUpdExt = timerfactory.Create<DataCollection.ITimeattUpd>(_TimeattUpd);
			
			return iTimeattUpdExt;
		}
	}
}
