//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLineGetContractFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLineGetContractFactory
	{
		public ISSSFSSROLineGetContract Create(IApplicationDB appDB)
		{
			var _SSSFSSROLineGetContract = new Logistics.FieldService.Requests.SSSFSSROLineGetContract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROLineGetContractExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLineGetContract>(_SSSFSSROLineGetContract);
			
			return iSSSFSSROLineGetContractExt;
		}
	}
}
