//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateUnitRegFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPortalCreateUnitRegFactory
	{
		public ISSSFSPortalCreateUnitReg Create(IApplicationDB appDB)
		{
			var _SSSFSPortalCreateUnitReg = new Logistics.FieldService.SSSFSPortalCreateUnitReg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalCreateUnitRegExt = timerfactory.Create<Logistics.FieldService.ISSSFSPortalCreateUnitReg>(_SSSFSPortalCreateUnitReg);
			
			return iSSSFSPortalCreateUnitRegExt;
		}
	}
}
