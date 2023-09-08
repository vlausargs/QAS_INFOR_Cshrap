//PROJECT NAME: Production
//CLASS NAME: CheckOperationExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckOperationExistsFactory
	{
		public ICheckOperationExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckOperationExists = new Production.CheckOperationExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckOperationExistsExt = timerfactory.Create<Production.ICheckOperationExists>(_CheckOperationExists);
			
			return iCheckOperationExistsExt;
		}
	}
}
