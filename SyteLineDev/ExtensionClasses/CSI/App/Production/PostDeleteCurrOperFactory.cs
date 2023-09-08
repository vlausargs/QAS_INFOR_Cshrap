//PROJECT NAME: Production
//CLASS NAME: PostDeleteCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PostDeleteCurrOperFactory
	{
		public IPostDeleteCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostDeleteCurrOper = new Production.PostDeleteCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostDeleteCurrOperExt = timerfactory.Create<Production.IPostDeleteCurrOper>(_PostDeleteCurrOper);
			
			return iPostDeleteCurrOperExt;
		}
	}
}
