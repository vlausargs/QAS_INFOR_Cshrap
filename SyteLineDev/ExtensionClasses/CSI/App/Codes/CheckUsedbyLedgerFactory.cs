//PROJECT NAME: CSICodes
//CLASS NAME: CheckUsedbyLedgerFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CheckUsedbyLedgerFactory
	{
		public ICheckUsedbyLedger Create(IApplicationDB appDB)
		{
			var _CheckUsedbyLedger = new Codes.CheckUsedbyLedger(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckUsedbyLedgerExt = timerfactory.Create<Codes.ICheckUsedbyLedger>(_CheckUsedbyLedger);
			
			return iCheckUsedbyLedgerExt;
		}
	}
}
