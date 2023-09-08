//PROJECT NAME: DataCollection
//CLASS NAME: DcjmLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcjmLogErrorFactory
	{
		public IDcjmLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcjmLogError = new DataCollection.DcjmLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjmLogErrorExt = timerfactory.Create<DataCollection.IDcjmLogError>(_DcjmLogError);
			
			return iDcjmLogErrorExt;
		}
	}
}
