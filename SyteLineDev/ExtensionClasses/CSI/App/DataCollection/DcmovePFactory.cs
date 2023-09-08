//PROJECT NAME: DataCollection
//CLASS NAME: DcmovePFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcmovePFactory
	{
		public IDcmoveP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcmoveP = new DataCollection.DcmoveP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmovePExt = timerfactory.Create<DataCollection.IDcmoveP>(_DcmoveP);
			
			return iDcmovePExt;
		}
	}
}
