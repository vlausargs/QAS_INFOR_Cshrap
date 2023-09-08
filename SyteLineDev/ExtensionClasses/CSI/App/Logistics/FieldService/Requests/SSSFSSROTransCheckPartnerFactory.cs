//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransCheckPartnerFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransCheckPartnerFactory
	{
		public ISSSFSSROTransCheckPartner Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransCheckPartner = new Logistics.FieldService.Requests.SSSFSSROTransCheckPartner(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransCheckPartnerExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransCheckPartner>(_SSSFSSROTransCheckPartner);
			
			return iSSSFSSROTransCheckPartnerExt;
		}
	}
}
