//PROJECT NAME: Reporting
//CLASS NAME: SSSVTXPostRegisterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSVTXPostRegisterFactory
	{
		public ISSSVTXPostRegister Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSVTXPostRegister = new Reporting.SSSVTXPostRegister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXPostRegisterExt = timerfactory.Create<Reporting.ISSSVTXPostRegister>(_SSSVTXPostRegister);
			
			return iSSSVTXPostRegisterExt;
		}
	}
}
