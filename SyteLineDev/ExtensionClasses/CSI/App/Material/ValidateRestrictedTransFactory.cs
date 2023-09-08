//PROJECT NAME: Material
//CLASS NAME: ValidateRestrictedTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ValidateRestrictedTransFactory
	{
		public IValidateRestrictedTrans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateRestrictedTrans = new Material.ValidateRestrictedTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateRestrictedTransExt = timerfactory.Create<Material.IValidateRestrictedTrans>(_ValidateRestrictedTrans);
			
			return iValidateRestrictedTransExt;
		}
	}
}
