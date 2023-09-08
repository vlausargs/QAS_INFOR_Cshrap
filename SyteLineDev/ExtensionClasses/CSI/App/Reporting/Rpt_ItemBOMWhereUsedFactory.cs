//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemBOMWhereUsedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemBOMWhereUsedFactory
	{
		public IRpt_ItemBOMWhereUsed Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemBOMWhereUsed = new Reporting.Rpt_ItemBOMWhereUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemBOMWhereUsedExt = timerfactory.Create<Reporting.IRpt_ItemBOMWhereUsed>(_Rpt_ItemBOMWhereUsed);
			
			return iRpt_ItemBOMWhereUsedExt;
		}
	}
}
