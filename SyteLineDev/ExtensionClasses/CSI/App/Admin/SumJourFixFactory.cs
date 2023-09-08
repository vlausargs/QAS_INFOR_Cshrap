//PROJECT NAME: Admin
//CLASS NAME: SumJourFixFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class SumJourFixFactory
	{
		public ISumJourFix Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SumJourFix = new Admin.SumJourFix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSumJourFixExt = timerfactory.Create<Admin.ISumJourFix>(_SumJourFix);
			
			return iSumJourFixExt;
		}
	}
}
