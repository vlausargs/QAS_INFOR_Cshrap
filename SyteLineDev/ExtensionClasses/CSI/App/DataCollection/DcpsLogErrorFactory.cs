//PROJECT NAME: DataCollection
//CLASS NAME: DcpsLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcpsLogErrorFactory
	{
		public IDcpsLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcpsLogError = new DataCollection.DcpsLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpsLogErrorExt = timerfactory.Create<DataCollection.IDcpsLogError>(_DcpsLogError);
			
			return iDcpsLogErrorExt;
		}
	}
}
