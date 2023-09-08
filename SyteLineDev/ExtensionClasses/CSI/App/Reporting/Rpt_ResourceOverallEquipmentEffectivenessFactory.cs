//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceOverallEquipmentEffectivenessFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceOverallEquipmentEffectivenessFactory
	{
		public IRpt_ResourceOverallEquipmentEffectiveness Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceOverallEquipmentEffectiveness = new Reporting.Rpt_ResourceOverallEquipmentEffectiveness(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceOverallEquipmentEffectivenessExt = timerfactory.Create<Reporting.IRpt_ResourceOverallEquipmentEffectiveness>(_Rpt_ResourceOverallEquipmentEffectiveness);
			
			return iRpt_ResourceOverallEquipmentEffectivenessExt;
		}
	}
}
