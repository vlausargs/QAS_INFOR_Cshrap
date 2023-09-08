//PROJECT NAME: DataCollection
//CLASS NAME: DcjitLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcjitLogErrorFactory
	{
		public IDcjitLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcjitLogError = new DataCollection.DcjitLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjitLogErrorExt = timerfactory.Create<DataCollection.IDcjitLogError>(_DcjitLogError);
			
			return iDcjitLogErrorExt;
		}
	}
}
