//PROJECT NAME: Finance
//CLASS NAME: GetGLBankRowPointerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetGLBankRowPointerFactory
	{
		public IGetGLBankRowPointer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetGLBankRowPointer = new Finance.GetGLBankRowPointer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetGLBankRowPointerExt = timerfactory.Create<Finance.IGetGLBankRowPointer>(_GetGLBankRowPointer);
			
			return iGetGLBankRowPointerExt;
		}
	}
}
