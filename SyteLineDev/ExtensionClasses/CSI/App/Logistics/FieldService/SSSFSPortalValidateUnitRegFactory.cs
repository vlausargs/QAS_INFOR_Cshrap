//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSPortalValidateUnitRegFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPortalValidateUnitRegFactory
	{
		public ISSSFSPortalValidateUnitReg Create(IApplicationDB appDB)
		{
			var _SSSFSPortalValidateUnitReg = new Logistics.FieldService.SSSFSPortalValidateUnitReg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalValidateUnitRegExt = timerfactory.Create<Logistics.FieldService.ISSSFSPortalValidateUnitReg>(_SSSFSPortalValidateUnitReg);
			
			return iSSSFSPortalValidateUnitRegExt;
		}
	}
}
