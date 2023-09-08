//PROJECT NAME: Production
//CLASS NAME: EngWBCreateResourceGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EngWBCreateResourceGroupFactory
	{
		public IEngWBCreateResourceGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EngWBCreateResourceGroup = new Production.EngWBCreateResourceGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBCreateResourceGroupExt = timerfactory.Create<Production.IEngWBCreateResourceGroup>(_EngWBCreateResourceGroup);
			
			return iEngWBCreateResourceGroupExt;
		}
	}
}
