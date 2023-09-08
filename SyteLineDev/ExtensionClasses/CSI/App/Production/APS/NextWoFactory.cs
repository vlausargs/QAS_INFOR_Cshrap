//PROJECT NAME: Production
//CLASS NAME: NextWoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class NextWoFactory
	{
		public INextWo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _NextWo = new Production.APS.NextWo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iNextWoExt = timerfactory.Create<Production.APS.INextWo>(_NextWo);
			
			return iNextWoExt;
		}
	}
}
