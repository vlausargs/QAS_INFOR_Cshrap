//PROJECT NAME: Logistics
//CLASS NAME: EstSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstSetGloVarFactory
	{
		public IEstSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstSetGloVar = new Logistics.Customer.EstSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstSetGloVarExt = timerfactory.Create<Logistics.Customer.IEstSetGloVar>(_EstSetGloVar);
			
			return iEstSetGloVarExt;
		}
	}
}
