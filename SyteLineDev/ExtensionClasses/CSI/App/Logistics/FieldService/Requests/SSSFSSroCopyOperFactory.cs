//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyOperFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyOperFactory
	{
		public ISSSFSSroCopyOper Create(IApplicationDB appDB)
		{
			var _SSSFSSroCopyOper = new Logistics.FieldService.Requests.SSSFSSroCopyOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyOperExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyOper>(_SSSFSSroCopyOper);
			
			return iSSSFSSroCopyOperExt;
		}
	}
}
