//PROJECT NAME: Material
//CLASS NAME: MtCodeListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class MtCodeListFactory
	{
		public IMtCodeList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MtCodeList = new Material.MtCodeList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMtCodeListExt = timerfactory.Create<Material.IMtCodeList>(_MtCodeList);
			
			return iMtCodeListExt;
		}
	}
}
