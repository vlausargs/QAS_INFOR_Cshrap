//PROJECT NAME: Logistics
//CLASS NAME: VerifyCustSeqDoesNotExistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class VerifyCustSeqDoesNotExistFactory
	{
		public IVerifyCustSeqDoesNotExist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VerifyCustSeqDoesNotExist = new Logistics.Customer.VerifyCustSeqDoesNotExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyCustSeqDoesNotExistExt = timerfactory.Create<Logistics.Customer.IVerifyCustSeqDoesNotExist>(_VerifyCustSeqDoesNotExist);
			
			return iVerifyCustSeqDoesNotExistExt;
		}
	}
}
