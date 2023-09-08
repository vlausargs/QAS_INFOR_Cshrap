//PROJECT NAME: Production
//CLASS NAME: JrtRgrpUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JrtRgrpUpdFactory
	{
		public IJrtRgrpUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JrtRgrpUpd = new Production.JrtRgrpUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJrtRgrpUpdExt = timerfactory.Create<Production.IJrtRgrpUpd>(_JrtRgrpUpd);
			
			return iJrtRgrpUpdExt;
		}
	}
}
