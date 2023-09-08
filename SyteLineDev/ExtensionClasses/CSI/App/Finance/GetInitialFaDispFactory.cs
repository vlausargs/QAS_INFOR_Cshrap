//PROJECT NAME: Finance
//CLASS NAME: GetInitialFaDispFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetInitialFaDispFactory
	{
		public IGetInitialFaDisp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetInitialFaDisp = new Finance.GetInitialFaDisp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInitialFaDispExt = timerfactory.Create<Finance.IGetInitialFaDisp>(_GetInitialFaDisp);
			
			return iGetInitialFaDispExt;
		}
	}
}
