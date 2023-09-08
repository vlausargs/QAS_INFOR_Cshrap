//PROJECT NAME: Finance
//CLASS NAME: MXTaxRegValidateFactory.cs

using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXTaxRegValidateFactory
	{
		public IMXTaxRegValidate Create(IApplicationDB appDB)
		{
			var _MXTaxRegValidate = new Finance.Mexican.MXTaxRegValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXTaxRegValidateExt = timerfactory.Create<Finance.Mexican.IMXTaxRegValidate>(_MXTaxRegValidate);
			
			return iMXTaxRegValidateExt;
		}
	}
}
