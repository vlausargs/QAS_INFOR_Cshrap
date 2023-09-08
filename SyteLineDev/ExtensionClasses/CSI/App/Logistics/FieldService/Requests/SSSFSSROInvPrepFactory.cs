//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvPrepFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROInvPrepFactory
	{
		public ISSSFSSROInvPrep Create(IApplicationDB appDB)
		{
			var _SSSFSSROInvPrep = new Logistics.FieldService.Requests.SSSFSSROInvPrep(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROInvPrepExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROInvPrep>(_SSSFSSROInvPrep);
			
			return iSSSFSSROInvPrepExt;
		}
	}
}
