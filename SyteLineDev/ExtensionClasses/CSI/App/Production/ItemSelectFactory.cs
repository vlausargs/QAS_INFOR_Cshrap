//PROJECT NAME: Production
//CLASS NAME: ItemSelectFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ItemSelectFactory
	{
		public IItemSelect Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemSelect = new Production.ItemSelect(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemSelectExt = timerfactory.Create<Production.IItemSelect>(_ItemSelect);
			
			return iItemSelectExt;
		}
	}
}
