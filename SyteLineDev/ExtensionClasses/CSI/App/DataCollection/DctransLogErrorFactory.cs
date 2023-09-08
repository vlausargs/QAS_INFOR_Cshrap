//PROJECT NAME: DataCollection
//CLASS NAME: DctransLogErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DctransLogErrorFactory
	{
		public IDctransLogError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DctransLogError = new DataCollection.DctransLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDctransLogErrorExt = timerfactory.Create<DataCollection.IDctransLogError>(_DctransLogError);
			
			return iDctransLogErrorExt;
		}
	}
}
