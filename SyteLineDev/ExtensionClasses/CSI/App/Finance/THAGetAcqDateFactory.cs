//PROJECT NAME: Finance
//CLASS NAME: THAGetAcqDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class THAGetAcqDateFactory
	{
		public ITHAGetAcqDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _THAGetAcqDate = new Finance.THAGetAcqDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAGetAcqDateExt = timerfactory.Create<Finance.ITHAGetAcqDate>(_THAGetAcqDate);
			
			return iTHAGetAcqDateExt;
		}
	}
}
