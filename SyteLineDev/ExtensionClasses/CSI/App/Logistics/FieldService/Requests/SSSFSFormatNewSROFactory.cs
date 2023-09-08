//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSFormatNewSROFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSFormatNewSROFactory
	{
		public ISSSFSFormatNewSRO Create(IApplicationDB appDB)
		{
			var _SSSFSFormatNewSRO = new Logistics.FieldService.Requests.SSSFSFormatNewSRO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSFormatNewSROExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSFormatNewSRO>(_SSSFSFormatNewSRO);
			
			return iSSSFSFormatNewSROExt;
		}
	}
}
