//PROJECT NAME: CSIFinance
//CLASS NAME: GetFaTransTotalFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GetFaTransTotalFactory
	{
		public IGetFaTransTotal Create(IApplicationDB appDB)
		{
			var _GetFaTransTotal = new Finance.GetFaTransTotal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFaTransTotalExt = timerfactory.Create<Finance.IGetFaTransTotal>(_GetFaTransTotal);
			
			return iGetFaTransTotalExt;
		}
	}
}
