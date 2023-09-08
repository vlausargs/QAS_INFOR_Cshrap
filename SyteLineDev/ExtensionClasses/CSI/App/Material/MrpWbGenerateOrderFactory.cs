//PROJECT NAME: Material
//CLASS NAME: MrpWbGenerateOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGenerateOrderFactory
	{
		public IMrpWbGenerateOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGenerateOrder = new Material.MrpWbGenerateOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGenerateOrderExt = timerfactory.Create<Material.IMrpWbGenerateOrder>(_MrpWbGenerateOrder);
			
			return iMrpWbGenerateOrderExt;
		}
	}
}
