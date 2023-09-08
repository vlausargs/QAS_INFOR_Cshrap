//PROJECT NAME: Codes
//CLASS NAME: LasttranFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class LasttranFactory
	{
		public ILasttran Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Lasttran = new Codes.Lasttran(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLasttranExt = timerfactory.Create<Codes.ILasttran>(_Lasttran);
			
			return iLasttranExt;
		}
	}
}
