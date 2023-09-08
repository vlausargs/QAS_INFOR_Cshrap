//PROJECT NAME: Production
//CLASS NAME: BflushLotValFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class BflushLotValFactory
	{
		public IBflushLotVal Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BflushLotVal = new Production.BflushLotVal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBflushLotValExt = timerfactory.Create<Production.IBflushLotVal>(_BflushLotVal);
			
			return iBflushLotValExt;
		}
	}
}
