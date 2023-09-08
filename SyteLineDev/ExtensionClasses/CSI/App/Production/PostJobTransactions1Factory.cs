//PROJECT NAME: Production
//CLASS NAME: PostJobTransactions1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PostJobTransactions1Factory
	{
		public IPostJobTransactions1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostJobTransactions1 = new Production.PostJobTransactions1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostJobTransactions1Ext = timerfactory.Create<Production.IPostJobTransactions1>(_PostJobTransactions1);
			
			return iPostJobTransactions1Ext;
		}
	}
}
