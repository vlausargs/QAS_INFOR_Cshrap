//PROJECT NAME: Codes
//CLASS NAME: DistacctWhereUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class DistacctWhereUsedFactory
	{
		public IDistacctWhereUsed Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DistacctWhereUsed = new Codes.DistacctWhereUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDistacctWhereUsedExt = timerfactory.Create<Codes.IDistacctWhereUsed>(_DistacctWhereUsed);
			
			return iDistacctWhereUsedExt;
		}
	}
}
