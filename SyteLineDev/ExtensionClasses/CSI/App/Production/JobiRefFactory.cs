//PROJECT NAME: Production
//CLASS NAME: JobiRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobiRefFactory
	{
		public IJobiRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobiRef = new Production.JobiRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobiRefExt = timerfactory.Create<Production.IJobiRef>(_JobiRef);
			
			return iJobiRefExt;
		}
	}
}
