//PROJECT NAME: Logistics
//CLASS NAME: CoCustSeqValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoCustSeqValidFactory
	{
		public ICoCustSeqValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoCustSeqValid = new Logistics.Customer.CoCustSeqValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoCustSeqValidExt = timerfactory.Create<Logistics.Customer.ICoCustSeqValid>(_CoCustSeqValid);
			
			return iCoCustSeqValidExt;
		}
	}
}
