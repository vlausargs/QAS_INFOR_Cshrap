//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSApsSyncImmediateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSApsSyncImmediateFactory
	{
		public ISSSFSApsSyncImmediate Create(IApplicationDB appDB)
		{
			var _SSSFSApsSyncImmediate = new Logistics.FieldService.Requests.SSSFSApsSyncImmediate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSApsSyncImmediateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSApsSyncImmediate>(_SSSFSApsSyncImmediate);
			
			return iSSSFSApsSyncImmediateExt;
		}
	}
}
