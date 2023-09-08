//PROJECT NAME: Codes
//CLASS NAME: AddToPortalOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class AddToPortalOrderFactory
	{
		public IAddToPortalOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AddToPortalOrder = new Codes.AddToPortalOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddToPortalOrderExt = timerfactory.Create<Codes.IAddToPortalOrder>(_AddToPortalOrder);
			
			return iAddToPortalOrderExt;
		}
	}
}
