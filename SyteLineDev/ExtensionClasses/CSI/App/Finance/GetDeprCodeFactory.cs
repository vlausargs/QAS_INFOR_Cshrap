//PROJECT NAME: CSIFinance
//CLASS NAME: GetDeprCodeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GetDeprCodeFactory
	{
		public IGetDeprCode Create(IApplicationDB appDB)
		{
			var _GetDeprCode = new Finance.GetDeprCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDeprCodeExt = timerfactory.Create<Finance.IGetDeprCode>(_GetDeprCode);
			
			return iGetDeprCodeExt;
		}
	}
}
