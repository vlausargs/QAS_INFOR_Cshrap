//PROJECT NAME: DataCollection
//CLASS NAME: TimeatDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class TimeatDFactory
	{
		public ITimeatD Create(IApplicationDB appDB)
		{
			var _TimeatD = new DataCollection.TimeatD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTimeatDExt = timerfactory.Create<DataCollection.ITimeatD>(_TimeatD);
			
			return iTimeatDExt;
		}
	}
}
