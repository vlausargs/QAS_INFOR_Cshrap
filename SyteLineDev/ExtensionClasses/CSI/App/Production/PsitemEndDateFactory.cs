//PROJECT NAME: Production
//CLASS NAME: PsitemEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PsitemEndDateFactory
	{
		public IPsitemEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PsitemEndDate = new Production.PsitemEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsitemEndDateExt = timerfactory.Create<Production.IPsitemEndDate>(_PsitemEndDate);
			
			return iPsitemEndDateExt;
		}
	}
}
