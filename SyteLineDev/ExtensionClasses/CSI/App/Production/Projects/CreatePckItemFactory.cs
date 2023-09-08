//PROJECT NAME: Production
//CLASS NAME: CreatePckItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class CreatePckItemFactory
	{
		public ICreatePckItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreatePckItem = new Production.Projects.CreatePckItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePckItemExt = timerfactory.Create<Production.Projects.ICreatePckItem>(_CreatePckItem);
			
			return iCreatePckItemExt;
		}
	}
}
