//PROJECT NAME: Logistics
//CLASS NAME: CoBlnSetGloVarFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoBlnSetGloVarFactory
	{
		public ICoBlnSetGloVar Create(IApplicationDB appDB)
		{
			var _CoBlnSetGloVar = new Logistics.Customer.CoBlnSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoBlnSetGloVarExt = timerfactory.Create<Logistics.Customer.ICoBlnSetGloVar>(_CoBlnSetGloVar);
			
			return iCoBlnSetGloVarExt;
		}
	}
}
