//PROJECT NAME: CSIProduct
//CLASS NAME: EcnMassFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class EcnMassFactory
	{
		public IEcnMass Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EcnMass = new Production.EcnMass(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcnMassExt = timerfactory.Create<Production.IEcnMass>(_EcnMass);
			
			return iEcnMassExt;
		}
	}
}
