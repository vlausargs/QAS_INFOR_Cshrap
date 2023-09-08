//PROJECT NAME: Finance
//CLASS NAME: MultiFSBInitPeriodsTableFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBInitPeriodsTableFactory
	{
		public IMultiFSBInitPeriodsTable Create(IApplicationDB appDB)
		{
			var _MultiFSBInitPeriodsTable = new Finance.MultiFSBInitPeriodsTable(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBInitPeriodsTableExt = timerfactory.Create<Finance.IMultiFSBInitPeriodsTable>(_MultiFSBInitPeriodsTable);
			
			return iMultiFSBInitPeriodsTableExt;
		}
	}
}
