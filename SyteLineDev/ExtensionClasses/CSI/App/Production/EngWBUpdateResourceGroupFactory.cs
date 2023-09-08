//PROJECT NAME: Production
//CLASS NAME: EngWBUpdateResourceGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EngWBUpdateResourceGroupFactory
	{
		public IEngWBUpdateResourceGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EngWBUpdateResourceGroup = new Production.EngWBUpdateResourceGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBUpdateResourceGroupExt = timerfactory.Create<Production.IEngWBUpdateResourceGroup>(_EngWBUpdateResourceGroup);
			
			return iEngWBUpdateResourceGroupExt;
		}
	}
}
