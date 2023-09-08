//PROJECT NAME: Material
//CLASS NAME: MsLotLovFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class MsLotLovFactory
	{
		public IMsLotLov Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MsLotLov = new Material.MsLotLov(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMsLotLovExt = timerfactory.Create<Material.IMsLotLov>(_MsLotLov);
			
			return iMsLotLovExt;
		}
	}
}
