//PROJECT NAME: DataCollection
//CLASS NAME: DcitemLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcitemLogErrorFactory
	{
		public IDcitemLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcitemLogError = new DataCollection.DcitemLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcitemLogErrorExt = timerfactory.Create<DataCollection.IDcitemLogError>(_DcitemLogError);
			
			return iDcitemLogErrorExt;
		}
	}
}
