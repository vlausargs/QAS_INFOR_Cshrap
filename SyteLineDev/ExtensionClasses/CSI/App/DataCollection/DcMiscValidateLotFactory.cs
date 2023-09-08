//PROJECT NAME: DataCollection
//CLASS NAME: DcMiscValidateLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcMiscValidateLotFactory
	{
		public IDcMiscValidateLot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcMiscValidateLot = new DataCollection.DcMiscValidateLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcMiscValidateLotExt = timerfactory.Create<DataCollection.IDcMiscValidateLot>(_DcMiscValidateLot);
			
			return iDcMiscValidateLotExt;
		}
	}
}
