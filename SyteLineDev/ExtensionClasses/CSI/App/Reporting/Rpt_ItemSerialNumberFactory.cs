//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemSerialNumberFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemSerialNumberFactory
	{
		public IRpt_ItemSerialNumber Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemSerialNumber = new Reporting.Rpt_ItemSerialNumber(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemSerialNumberExt = timerfactory.Create<Reporting.IRpt_ItemSerialNumber>(_Rpt_ItemSerialNumber);
			
			return iRpt_ItemSerialNumberExt;
		}
	}
}
