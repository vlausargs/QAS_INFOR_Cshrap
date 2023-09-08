//PROJECT NAME: Reporting
//CLASS NAME: SetGoBDMediaDataFactory.cs

using CSI.MG;

namespace CSI.Reporting.Germany
{
	public class SetGoBDMediaDataFactory
	{
		public ISetGoBDMediaData Create(IApplicationDB appDB)
		{
			var _SetGoBDMediaData = new Reporting.Germany.SetGoBDMediaData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetGoBDMediaDataExt = timerfactory.Create<Reporting.Germany.ISetGoBDMediaData>(_SetGoBDMediaData);
			
			return iSetGoBDMediaDataExt;
		}
	}
}
