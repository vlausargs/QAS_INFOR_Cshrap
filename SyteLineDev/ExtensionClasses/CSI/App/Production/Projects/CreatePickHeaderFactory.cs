//PROJECT NAME: Production
//CLASS NAME: CreatePickHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class CreatePickHeaderFactory
	{
		public ICreatePickHeader Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreatePickHeader = new Production.Projects.CreatePickHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePickHeaderExt = timerfactory.Create<Production.Projects.ICreatePickHeader>(_CreatePickHeader);
			
			return iCreatePickHeaderExt;
		}
	}
}
