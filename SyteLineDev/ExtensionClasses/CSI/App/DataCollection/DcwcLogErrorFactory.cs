//PROJECT NAME: DataCollection
//CLASS NAME: DcwcLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcwcLogErrorFactory
	{
		public IDcwcLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcwcLogError = new DataCollection.DcwcLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcLogErrorExt = timerfactory.Create<DataCollection.IDcwcLogError>(_DcwcLogError);
			
			return iDcwcLogErrorExt;
		}
	}
}
