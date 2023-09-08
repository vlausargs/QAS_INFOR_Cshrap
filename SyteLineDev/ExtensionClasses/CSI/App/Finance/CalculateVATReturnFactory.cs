//PROJECT NAME: CSIFinance
//CLASS NAME: CalculateVATReturnFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class CalculateVATReturnFactory
	{
		public ICalculateVATReturn Create(IApplicationDB appDB)
		{
			var _CalculateVATReturn = new Finance.CalculateVATReturn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalculateVATReturnExt = timerfactory.Create<Finance.ICalculateVATReturn>(_CalculateVATReturn);
			
			return iCalculateVATReturnExt;
		}
	}
}
