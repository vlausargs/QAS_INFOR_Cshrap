//PROJECT NAME: DataCollection
//CLASS NAME: DctsPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DctsPFactory
	{
		public IDctsP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DctsP = new DataCollection.DctsP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctsPExt = timerfactory.Create<DataCollection.IDctsP>(_DctsP);
			
			return iDctsPExt;
		}
	}
}
