//PROJECT NAME: DataCollection
//CLASS NAME: dctsLotRvallotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class dctsLotRvallotFactory
	{
		public IdctsLotRvallot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _dctsLotRvallot = new DataCollection.dctsLotRvallot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var idctsLotRvallotExt = timerfactory.Create<DataCollection.IdctsLotRvallot>(_dctsLotRvallot);
			
			return idctsLotRvallotExt;
		}
	}
}
