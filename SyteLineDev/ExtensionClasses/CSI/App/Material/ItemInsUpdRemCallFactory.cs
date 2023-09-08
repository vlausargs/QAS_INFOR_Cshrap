//PROJECT NAME: Material
//CLASS NAME: ItemInsUpdRemCallFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemInsUpdRemCallFactory
	{
		public IItemInsUpdRemCall Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemInsUpdRemCall = new Material.ItemInsUpdRemCall(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemInsUpdRemCallExt = timerfactory.Create<Material.IItemInsUpdRemCall>(_ItemInsUpdRemCall);
			
			return iItemInsUpdRemCallExt;
		}
	}
}
