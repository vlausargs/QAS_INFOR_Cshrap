//PROJECT NAME: DataCollection
//CLASS NAME: DcDcsfcPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcDcsfcPFactory
	{
		public IDcDcsfcP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcDcsfcP = new DataCollection.DcDcsfcP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcDcsfcPExt = timerfactory.Create<DataCollection.IDcDcsfcP>(_DcDcsfcP);
			
			return iDcDcsfcPExt;
		}
	}
}
