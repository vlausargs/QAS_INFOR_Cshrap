//PROJECT NAME: DataCollection
//CLASS NAME: DcAJitFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DcAJitFactory
	{
		public IDcAJit Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DcAJit = new DataCollection.DcAJit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAJitExt = timerfactory.Create<DataCollection.IDcAJit>(_DcAJit);
			
			return iDcAJitExt;
		}
	}
}
