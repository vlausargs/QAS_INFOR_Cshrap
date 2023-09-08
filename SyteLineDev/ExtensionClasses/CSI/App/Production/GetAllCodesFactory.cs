//PROJECT NAME: Production
//CLASS NAME: GetAllCodesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class GetAllCodesFactory
	{
		public IGetAllCodes Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetAllCodes = new Production.GetAllCodes(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAllCodesExt = timerfactory.Create<Production.IGetAllCodes>(_GetAllCodes);

			return iGetAllCodesExt;
		}
	}
}
