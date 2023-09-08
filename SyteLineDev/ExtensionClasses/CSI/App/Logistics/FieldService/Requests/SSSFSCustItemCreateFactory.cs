//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCustItemCreateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSCustItemCreateFactory
	{
		public ISSSFSCustItemCreate Create(IApplicationDB appDB)
		{
			var _SSSFSCustItemCreate = new Logistics.FieldService.Requests.SSSFSCustItemCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSCustItemCreateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSCustItemCreate>(_SSSFSCustItemCreate);
			
			return iSSSFSCustItemCreateExt;
		}
	}
}
