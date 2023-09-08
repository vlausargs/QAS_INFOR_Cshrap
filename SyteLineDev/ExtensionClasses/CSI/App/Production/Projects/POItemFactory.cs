//PROJECT NAME: Production
//CLASS NAME: POItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class POItemFactory
	{
		public IPOItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _POItem = new Production.Projects.POItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOItemExt = timerfactory.Create<Production.Projects.IPOItem>(_POItem);
			
			return iPOItemExt;
		}
	}
}
