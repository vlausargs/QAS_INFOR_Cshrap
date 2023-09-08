//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InactiveAccountNumbersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InactiveAccountNumbersFactory
	{
		public IRpt_InactiveAccountNumbers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InactiveAccountNumbers = new Reporting.Rpt_InactiveAccountNumbers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InactiveAccountNumbersExt = timerfactory.Create<Reporting.IRpt_InactiveAccountNumbers>(_Rpt_InactiveAccountNumbers);
			
			return iRpt_InactiveAccountNumbersExt;
		}
	}
}
