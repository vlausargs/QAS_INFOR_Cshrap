//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdCnvtAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdCnvtAmtFactory
	{
		public IArpmtdCnvtAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtdCnvtAmt = new Logistics.Customer.ArpmtdCnvtAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdCnvtAmtExt = timerfactory.Create<Logistics.Customer.IArpmtdCnvtAmt>(_ArpmtdCnvtAmt);
			
			return iArpmtdCnvtAmtExt;
		}
	}
}
