//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROOperValidSROFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROOperValidSROFactory
	{
		public ISSSFSSROOperValidSRO Create(IApplicationDB appDB)
		{
			var _SSSFSSROOperValidSRO = new Logistics.FieldService.Requests.SSSFSSROOperValidSRO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROOperValidSROExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROOperValidSRO>(_SSSFSSROOperValidSRO);
			
			return iSSSFSSROOperValidSROExt;
		}
	}
}
