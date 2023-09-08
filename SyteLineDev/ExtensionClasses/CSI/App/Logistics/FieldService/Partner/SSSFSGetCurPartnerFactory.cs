//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSGetCurPartnerFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSGetCurPartnerFactory
	{
		public ISSSFSGetCurPartner Create(IApplicationDB appDB)
		{
			var _SSSFSGetCurPartner = new Logistics.FieldService.Partner.SSSFSGetCurPartner(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetCurPartnerExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSGetCurPartner>(_SSSFSGetCurPartner);
			
			return iSSSFSGetCurPartnerExt;
		}
	}
}
