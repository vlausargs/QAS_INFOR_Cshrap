//PROJECT NAME: Codes
//CLASS NAME: CLM_ESBCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_ESBCodeFactory
	{
		public ICLM_ESBCode Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCode = new Codes.CLM_ESBCode(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCodeExt = timerfactory.Create<Codes.ICLM_ESBCode>(_CLM_ESBCode);
			
			return iCLM_ESBCodeExt;
		}
	}
}
