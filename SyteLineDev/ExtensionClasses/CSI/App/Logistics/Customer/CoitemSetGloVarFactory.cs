//PROJECT NAME: Logistics
//CLASS NAME: CoitemSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoitemSetGloVarFactory
	{
		public ICoitemSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoitemSetGloVar = new Logistics.Customer.CoitemSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoitemSetGloVarExt = timerfactory.Create<Logistics.Customer.ICoitemSetGloVar>(_CoitemSetGloVar);
			
			return iCoitemSetGloVarExt;
		}
	}
}
