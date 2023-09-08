//PROJECT NAME: Logistics
//CLASS NAME: PoandPohFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class PoandPohFactory
	{
		public IPoandPoh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PoandPoh = new Logistics.Vendor.PoandPoh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoandPohExt = timerfactory.Create<Logistics.Vendor.IPoandPoh>(_PoandPoh);
			
			return iPoandPohExt;
		}
	}
}
