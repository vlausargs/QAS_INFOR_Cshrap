//PROJECT NAME: Material
//CLASS NAME: GetPurchasingParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetPurchasingParmsFactory
	{
		public IGetPurchasingParms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetPurchasingParms = new Material.GetPurchasingParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPurchasingParmsExt = timerfactory.Create<Material.IGetPurchasingParms>(_GetPurchasingParms);
			
			return iGetPurchasingParmsExt;
		}
	}
}
