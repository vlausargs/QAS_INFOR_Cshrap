//PROJECT NAME: DataCollection
//CLASS NAME: DccoLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DccoLogErrorFactory
	{
		public IDccoLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DccoLogError = new DataCollection.DccoLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDccoLogErrorExt = timerfactory.Create<DataCollection.IDccoLogError>(_DccoLogError);
			
			return iDccoLogErrorExt;
		}
	}
}
