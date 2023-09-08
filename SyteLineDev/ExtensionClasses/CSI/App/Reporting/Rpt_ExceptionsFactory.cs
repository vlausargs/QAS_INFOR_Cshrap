//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ExceptionsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ExceptionsFactory
	{
		public IRpt_Exceptions Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Exceptions = new Reporting.Rpt_Exceptions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ExceptionsExt = timerfactory.Create<Reporting.IRpt_Exceptions>(_Rpt_Exceptions);
			
			return iRpt_ExceptionsExt;
		}
	}
}
