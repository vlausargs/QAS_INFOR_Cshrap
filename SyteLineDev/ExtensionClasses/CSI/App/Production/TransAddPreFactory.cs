//PROJECT NAME: Production
//CLASS NAME: TransAddPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class TransAddPreFactory
	{
		public ITransAddPre Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransAddPre = new Production.TransAddPre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransAddPreExt = timerfactory.Create<Production.ITransAddPre>(_TransAddPre);
			
			return iTransAddPreExt;
		}
	}
}
