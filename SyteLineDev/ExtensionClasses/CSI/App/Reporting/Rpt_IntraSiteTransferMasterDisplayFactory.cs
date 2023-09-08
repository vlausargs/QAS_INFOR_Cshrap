//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IntraSiteTransferMasterDisplayFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IntraSiteTransferMasterDisplayFactory
	{
		public IRpt_IntraSiteTransferMasterDisplay Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IntraSiteTransferMasterDisplay = new Reporting.Rpt_IntraSiteTransferMasterDisplay(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IntraSiteTransferMasterDisplayExt = timerfactory.Create<Reporting.IRpt_IntraSiteTransferMasterDisplay>(_Rpt_IntraSiteTransferMasterDisplay);
			
			return iRpt_IntraSiteTransferMasterDisplayExt;
		}
	}
}
