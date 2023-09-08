//PROJECT NAME: Logistics
//CLASS NAME: ValidateArtranInvNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateArtranInvNumFactory
	{
		public IValidateArtranInvNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateArtranInvNum = new Logistics.Customer.ValidateArtranInvNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateArtranInvNumExt = timerfactory.Create<Logistics.Customer.IValidateArtranInvNum>(_ValidateArtranInvNum);
			
			return iValidateArtranInvNumExt;
		}
	}
}
