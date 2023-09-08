//PROJECT NAME: Material
//CLASS NAME: ItemEnableFormFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemEnableFormFactory
	{
		public IItemEnableForm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemEnableForm = new Material.ItemEnableForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemEnableFormExt = timerfactory.Create<Material.IItemEnableForm>(_ItemEnableForm);
			
			return iItemEnableFormExt;
		}
	}
}
