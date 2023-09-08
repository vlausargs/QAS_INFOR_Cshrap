//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedCurrentBillofMaterialFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IndentedCurrentBillofMaterialFactory
	{
		public IRpt_IndentedCurrentBillofMaterial Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IndentedCurrentBillofMaterial = new Reporting.Rpt_IndentedCurrentBillofMaterial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IndentedCurrentBillofMaterialExt = timerfactory.Create<Reporting.IRpt_IndentedCurrentBillofMaterial>(_Rpt_IndentedCurrentBillofMaterial);
			
			return iRpt_IndentedCurrentBillofMaterialExt;
		}
	}
}
