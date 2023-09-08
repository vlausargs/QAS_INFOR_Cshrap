//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyLinesFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyLinesFactory
	{
		public ISSSFSSroCopyLines Create(IApplicationDB appDB)
		{
			var _SSSFSSroCopyLines = new Logistics.FieldService.Requests.SSSFSSroCopyLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyLinesExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyLines>(_SSSFSSroCopyLines);
			
			return iSSSFSSroCopyLinesExt;
		}
	}
}
