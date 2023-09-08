//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSAcmGenerateSchedFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmGenerateSchedFactory
	{
		public ISSSFSAcmGenerateSched Create(IApplicationDB appDB)
		{
			var _SSSFSAcmGenerateSched = new Logistics.FieldService.SSSFSAcmGenerateSched(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSAcmGenerateSchedExt = timerfactory.Create<Logistics.FieldService.ISSSFSAcmGenerateSched>(_SSSFSAcmGenerateSched);
			
			return iSSSFSAcmGenerateSchedExt;
		}
	}
}
