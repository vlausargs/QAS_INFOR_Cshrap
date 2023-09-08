//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdSetGloVarFactory
	{
		public IArpmtdSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtdSetGloVar = new Logistics.Customer.ArpmtdSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdSetGloVarExt = timerfactory.Create<Logistics.Customer.IArpmtdSetGloVar>(_ArpmtdSetGloVar);
			
			return iArpmtdSetGloVarExt;
		}
	}
}
