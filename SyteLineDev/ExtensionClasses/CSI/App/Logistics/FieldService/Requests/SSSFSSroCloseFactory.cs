//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCloFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCloFactory
	{
		public ISSSFSSroClo Create(IApplicationDB appDB)
		{
			var _SSSFSSroClo = new Logistics.FieldService.Requests.SSSFSSroClo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCloExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroClo>(_SSSFSSroClo);
			
			return iSSSFSSroCloExt;
		}
	}
}
