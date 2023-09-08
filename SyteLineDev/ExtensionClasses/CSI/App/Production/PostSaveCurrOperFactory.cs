//PROJECT NAME: Production
//CLASS NAME: PostSaveCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PostSaveCurrOperFactory
	{
		public IPostSaveCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostSaveCurrOper = new Production.PostSaveCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostSaveCurrOperExt = timerfactory.Create<Production.IPostSaveCurrOper>(_PostSaveCurrOper);
			
			return iPostSaveCurrOperExt;
		}
	}
}
