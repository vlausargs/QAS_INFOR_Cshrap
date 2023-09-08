//PROJECT NAME: Material
//CLASS NAME: FeatStrValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class FeatStrValidateFactory
	{
		public IFeatStrValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FeatStrValidate = new Material.FeatStrValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFeatStrValidateExt = timerfactory.Create<Material.IFeatStrValidate>(_FeatStrValidate);
			
			return iFeatStrValidateExt;
		}
	}
}
