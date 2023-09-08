//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSUnitGetSROTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitGetSROTypeFactory
	{
		public ISSSFSUnitGetSROType Create(IApplicationDB appDB)
		{
			var _SSSFSUnitGetSROType = new Logistics.FieldService.SSSFSUnitGetSROType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitGetSROTypeExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitGetSROType>(_SSSFSUnitGetSROType);
			
			return iSSSFSUnitGetSROTypeExt;
		}
	}
}
