//PROJECT NAME: Codes
//CLASS NAME: CLM_DimensionAttributesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_DimensionAttributesFactory
	{
		public ICLM_DimensionAttributes Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DimensionAttributes = new Codes.CLM_DimensionAttributes(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DimensionAttributesExt = timerfactory.Create<Codes.ICLM_DimensionAttributes>(_CLM_DimensionAttributes);
			
			return iCLM_DimensionAttributesExt;
		}
	}
}
