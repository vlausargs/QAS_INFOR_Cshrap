//PROJECT NAME: CSICodes
//CLASS NAME: GetARAgeDaysFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetARAgeDaysFactory
	{
		public IGetARAgeDays Create(IApplicationDB appDB)
		{
			var _GetARAgeDays = new Codes.GetARAgeDays(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetARAgeDaysExt = timerfactory.Create<Codes.IGetARAgeDays>(_GetARAgeDays);
			
			return iGetARAgeDaysExt;
		}
	}
}
