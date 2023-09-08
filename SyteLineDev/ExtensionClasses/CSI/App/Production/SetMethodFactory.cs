//PROJECT NAME: Production
//CLASS NAME: SetMethodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SetMethodFactory
	{
		public ISetMethod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetMethod = new Production.SetMethod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetMethodExt = timerfactory.Create<Production.ISetMethod>(_SetMethod);
			
			return iSetMethodExt;
		}
	}
}
