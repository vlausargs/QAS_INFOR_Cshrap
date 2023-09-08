//PROJECT NAME: Material
//CLASS NAME: ItemInsUpdValidatorRemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemInsUpdValidatorRemFactory
	{
		public IItemInsUpdValidatorRem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemInsUpdValidatorRem = new Material.ItemInsUpdValidatorRem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemInsUpdValidatorRemExt = timerfactory.Create<Material.IItemInsUpdValidatorRem>(_ItemInsUpdValidatorRem);
			
			return iItemInsUpdValidatorRemExt;
		}
	}
}
