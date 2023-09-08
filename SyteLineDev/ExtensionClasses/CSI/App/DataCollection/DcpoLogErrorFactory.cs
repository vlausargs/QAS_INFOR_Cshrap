//PROJECT NAME: DataCollection
//CLASS NAME: DcpoLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcpoLogErrorFactory
	{
		public IDcpoLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcpoLogError = new DataCollection.DcpoLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpoLogErrorExt = timerfactory.Create<DataCollection.IDcpoLogError>(_DcpoLogError);
			
			return iDcpoLogErrorExt;
		}
	}
}
