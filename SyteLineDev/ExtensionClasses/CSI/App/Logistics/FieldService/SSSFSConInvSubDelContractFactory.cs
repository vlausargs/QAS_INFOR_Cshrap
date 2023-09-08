//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConInvSubDelContractFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubDelContractFactory
	{
		public ISSSFSConInvSubDelContract Create(IApplicationDB appDB)
		{
			var _SSSFSConInvSubDelContract = new Logistics.FieldService.SSSFSConInvSubDelContract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConInvSubDelContractExt = timerfactory.Create<Logistics.FieldService.ISSSFSConInvSubDelContract>(_SSSFSConInvSubDelContract);
			
			return iSSSFSConInvSubDelContractExt;
		}
	}
}
