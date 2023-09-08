//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncCalcDurationFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncCalcDurationFactory
	{
		public ISSSFSIncCalcDuration Create(IApplicationDB appDB)
		{
			var _SSSFSIncCalcDuration = new Logistics.FieldService.CallCenter.SSSFSIncCalcDuration(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncCalcDurationExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncCalcDuration>(_SSSFSIncCalcDuration);
			
			return iSSSFSIncCalcDurationExt;
		}
	}
}
