//PROJECT NAME: CSICodes
//CLASS NAME: CLM_DimSubCollectionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_DimSubCollectionFactory
	{
		public ICLM_DimSubCollection Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DimSubCollection = new Codes.CLM_DimSubCollection(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DimSubCollectionExt = timerfactory.Create<Codes.ICLM_DimSubCollection>(_CLM_DimSubCollection);
			
			return iCLM_DimSubCollectionExt;
		}
	}
}
