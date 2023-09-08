//PROJECT NAME: Production
//CLASS NAME: MO_LoadCoJobtranitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class MO_LoadCoJobtranitemFactory
	{
		public IMO_LoadCoJobtranitem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_LoadCoJobtranitem = new Production.MO_LoadCoJobtranitem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_LoadCoJobtranitemExt = timerfactory.Create<Production.IMO_LoadCoJobtranitem>(_MO_LoadCoJobtranitem);
			
			return iMO_LoadCoJobtranitemExt;
		}
	}
}
