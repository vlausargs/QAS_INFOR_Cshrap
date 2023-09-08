//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncEscalUtilFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncEscalUtilFactory
	{
		public ISSSFSIncEscalUtil Create(IApplicationDB appDB)
		{
			var _SSSFSIncEscalUtil = new Logistics.FieldService.CallCenter.SSSFSIncEscalUtil(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncEscalUtilExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncEscalUtil>(_SSSFSIncEscalUtil);
			
			return iSSSFSIncEscalUtilExt;
		}
	}
}
