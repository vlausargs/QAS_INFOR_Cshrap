//PROJECT NAME: DataCollection
//CLASS NAME: DccycPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DccycPFactory
	{
		public IDccycP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DccycP = new DataCollection.DccycP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccycPExt = timerfactory.Create<DataCollection.IDccycP>(_DccycP);
			
			return iDccycPExt;
		}
	}
}
