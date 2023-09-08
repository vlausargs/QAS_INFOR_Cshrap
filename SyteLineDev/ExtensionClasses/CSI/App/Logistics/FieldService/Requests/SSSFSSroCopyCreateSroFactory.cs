//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyCreateSroFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroCopyCreateSroFactory
	{
		public ISSSFSSroCopyCreateSro Create(IApplicationDB appDB)
		{
			var _SSSFSSroCopyCreateSro = new Logistics.FieldService.Requests.SSSFSSroCopyCreateSro(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroCopyCreateSroExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyCreateSro>(_SSSFSSroCopyCreateSro);
			
			return iSSSFSSroCopyCreateSroExt;
		}
	}
}
