//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcsfcLogErrorFactory
	{
		public IDcsfcLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcsfcLogError = new DataCollection.DcsfcLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcLogErrorExt = timerfactory.Create<DataCollection.IDcsfcLogError>(_DcsfcLogError);
			
			return iDcsfcLogErrorExt;
		}
	}
}
