//PROJECT NAME: Codes
//CLASS NAME: GetPrBankCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetPrBankCodeFactory
	{
		public IGetPrBankCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetPrBankCode = new Codes.GetPrBankCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPrBankCodeExt = timerfactory.Create<Codes.IGetPrBankCode>(_GetPrBankCode);
			
			return iGetPrBankCodeExt;
		}
	}
}
