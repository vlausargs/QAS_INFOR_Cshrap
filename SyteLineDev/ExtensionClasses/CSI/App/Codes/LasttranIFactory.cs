//PROJECT NAME: Codes
//CLASS NAME: LasttranIFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class LasttranIFactory
	{
		public ILasttranI Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LasttranI = new Codes.LasttranI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLasttranIExt = timerfactory.Create<Codes.ILasttranI>(_LasttranI);
			
			return iLasttranIExt;
		}
	}
}
