//PROJECT NAME: Codes
//CLASS NAME: EFTMappedPivotFieldsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class EFTMappedPivotFieldsFactory
	{
		public IEFTMappedPivotFields Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EFTMappedPivotFields = new Codes.EFTMappedPivotFields(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTMappedPivotFieldsExt = timerfactory.Create<Codes.IEFTMappedPivotFields>(_EFTMappedPivotFields);
			
			return iEFTMappedPivotFieldsExt;
		}
	}
}
