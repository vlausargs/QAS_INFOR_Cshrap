//PROJECT NAME: Production
//CLASS NAME: ApsCalcSubJobDatesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ApsCalcSubJobDatesFactory
	{
		public IApsCalcSubJobDates Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsCalcSubJobDates = new Production.ApsCalcSubJobDates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsCalcSubJobDatesExt = timerfactory.Create<Production.IApsCalcSubJobDates>(_ApsCalcSubJobDates);
			
			return iApsCalcSubJobDatesExt;
		}
	}
}
