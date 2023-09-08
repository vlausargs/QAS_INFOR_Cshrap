//PROJECT NAME: Logistics
//CLASS NAME: EdiCoitemSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EdiCoitemSetGloVarFactory
	{
		public IEdiCoitemSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EdiCoitemSetGloVar = new Logistics.Customer.EdiCoitemSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEdiCoitemSetGloVarExt = timerfactory.Create<Logistics.Customer.IEdiCoitemSetGloVar>(_EdiCoitemSetGloVar);
			
			return iEdiCoitemSetGloVarExt;
		}
	}
}
