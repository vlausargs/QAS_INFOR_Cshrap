//PROJECT NAME: Production
//CLASS NAME: SetVariablesForCurrOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class SetVariablesForCurrOperFactory
	{
		public ISetVariablesForCurrOper Create(IApplicationDB appDB)
		{
			var _SetVariablesForCurrOper = new Production.SetVariablesForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetVariablesForCurrOperExt = timerfactory.Create<Production.ISetVariablesForCurrOper>(_SetVariablesForCurrOper);
			
			return iSetVariablesForCurrOperExt;
		}
	}
}
