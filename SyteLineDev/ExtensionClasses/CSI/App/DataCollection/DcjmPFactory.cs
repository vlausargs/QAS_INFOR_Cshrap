//PROJECT NAME: DataCollection
//CLASS NAME: DcjmPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcjmPFactory
	{
		public IDcjmP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcjmP = new DataCollection.DcjmP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjmPExt = timerfactory.Create<DataCollection.IDcjmP>(_DcjmP);
			
			return iDcjmPExt;
		}
	}
}
