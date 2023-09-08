//PROJECT NAME: Production
//CLASS NAME: RevCalcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class RevCalcFactory
	{
		public IRevCalc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RevCalc = new Production.Projects.RevCalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRevCalcExt = timerfactory.Create<Production.Projects.IRevCalc>(_RevCalc);
			
			return iRevCalcExt;
		}
	}
}
