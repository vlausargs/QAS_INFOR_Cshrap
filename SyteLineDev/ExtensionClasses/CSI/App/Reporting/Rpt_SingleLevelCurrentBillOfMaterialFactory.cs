//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SingleLevelCurrentBillOfMaterialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SingleLevelCurrentBillOfMaterialFactory
	{
		public IRpt_SingleLevelCurrentBillOfMaterial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SingleLevelCurrentBillOfMaterial = new Reporting.Rpt_SingleLevelCurrentBillOfMaterial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SingleLevelCurrentBillOfMaterialExt = timerfactory.Create<Reporting.IRpt_SingleLevelCurrentBillOfMaterial>(_Rpt_SingleLevelCurrentBillOfMaterial);
			
			return iRpt_SingleLevelCurrentBillOfMaterialExt;
		}
	}
}
