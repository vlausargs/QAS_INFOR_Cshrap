//PROJECT NAME: Material
//CLASS NAME: ValidateNonNettableItemLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ValidateNonNettableItemLocFactory
	{
		public IValidateNonNettableItemLoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateNonNettableItemLoc = new Material.ValidateNonNettableItemLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateNonNettableItemLocExt = timerfactory.Create<Material.IValidateNonNettableItemLoc>(_ValidateNonNettableItemLoc);
			
			return iValidateNonNettableItemLocExt;
		}
	}
}
