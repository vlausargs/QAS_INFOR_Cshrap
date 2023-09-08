//PROJECT NAME: Production
//CLASS NAME: PSGenerateTransNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PSGenerateTransNumFactory
	{
		public IPSGenerateTransNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PSGenerateTransNum = new Production.PSGenerateTransNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSGenerateTransNumExt = timerfactory.Create<Production.IPSGenerateTransNum>(_PSGenerateTransNum);
			
			return iPSGenerateTransNumExt;
		}
	}
}
