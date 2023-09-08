//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConfigValidateLotFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigValidateLotFactory
	{
		public ISSSFSConfigValidateLot Create(IApplicationDB appDB)
		{
			var _SSSFSConfigValidateLot = new Logistics.FieldService.SSSFSConfigValidateLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConfigValidateLotExt = timerfactory.Create<Logistics.FieldService.ISSSFSConfigValidateLot>(_SSSFSConfigValidateLot);
			
			return iSSSFSConfigValidateLotExt;
		}
	}
}
