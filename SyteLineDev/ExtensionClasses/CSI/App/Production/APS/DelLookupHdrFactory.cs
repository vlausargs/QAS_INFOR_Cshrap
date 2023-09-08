//PROJECT NAME: Production
//CLASS NAME: DelLookupHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class DelLookupHdrFactory
	{
		public IDelLookupHdr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DelLookupHdr = new Production.APS.DelLookupHdr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelLookupHdrExt = timerfactory.Create<Production.APS.IDelLookupHdr>(_DelLookupHdr);
			
			return iDelLookupHdrExt;
		}
	}
}
