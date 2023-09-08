//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyTransFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyTransFactory
	{
		public ISSSFSSroCopyTrans Create(IApplicationDB appDB)
		{
			var _SSSFSSroCopyTrans = new Logistics.FieldService.Requests.SSSFSSroCopyTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyTransExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyTrans>(_SSSFSSroCopyTrans);
			
			return iSSSFSSroCopyTransExt;
		}
	}
}
