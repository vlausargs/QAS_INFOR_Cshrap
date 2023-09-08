//PROJECT NAME: Production
//CLASS NAME: CalculateRatio2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CalculateRatio2Factory
	{
		public ICalculateRatio2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalculateRatio2 = new Production.CalculateRatio2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalculateRatio2Ext = timerfactory.Create<Production.ICalculateRatio2>(_CalculateRatio2);
			
			return iCalculateRatio2Ext;
		}
	}
}
