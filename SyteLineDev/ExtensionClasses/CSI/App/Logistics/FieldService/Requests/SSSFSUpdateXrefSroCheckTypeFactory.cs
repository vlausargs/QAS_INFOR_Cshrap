//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUpdateXrefSroCheckTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSUpdateXrefSroCheckTypeFactory
	{
		public ISSSFSUpdateXrefSroCheckType Create(IApplicationDB appDB)
		{
			var _SSSFSUpdateXrefSroCheckType = new Logistics.FieldService.Requests.SSSFSUpdateXrefSroCheckType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUpdateXrefSroCheckTypeExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSUpdateXrefSroCheckType>(_SSSFSUpdateXrefSroCheckType);
			
			return iSSSFSUpdateXrefSroCheckTypeExt;
		}
	}
}
