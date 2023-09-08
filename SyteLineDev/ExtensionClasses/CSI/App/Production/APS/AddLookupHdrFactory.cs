//PROJECT NAME: Production
//CLASS NAME: AddLookupHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class AddLookupHdrFactory
	{
		public IAddLookupHdr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AddLookupHdr = new Production.APS.AddLookupHdr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddLookupHdrExt = timerfactory.Create<Production.APS.IAddLookupHdr>(_AddLookupHdr);
			
			return iAddLookupHdrExt;
		}
	}
}
