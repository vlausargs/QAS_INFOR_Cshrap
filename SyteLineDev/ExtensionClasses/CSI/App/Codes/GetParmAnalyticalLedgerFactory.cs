//PROJECT NAME: CSICodes
//CLASS NAME: GetParmAnalyticalLedgerFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetParmAnalyticalLedgerFactory
	{
		public IGetParmAnalyticalLedger Create(IApplicationDB appDB)
		{
			var _GetParmAnalyticalLedger = new Codes.GetParmAnalyticalLedger(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmAnalyticalLedgerExt = timerfactory.Create<Codes.IGetParmAnalyticalLedger>(_GetParmAnalyticalLedger);
			
			return iGetParmAnalyticalLedgerExt;
		}
	}
}
