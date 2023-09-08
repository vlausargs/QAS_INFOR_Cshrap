//PROJECT NAME: Production
//CLASS NAME: GetProjInfoByCustFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class GetProjInfoByCustFactory
	{
		public IGetProjInfoByCust Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetProjInfoByCust = new Production.Projects.GetProjInfoByCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjInfoByCustExt = timerfactory.Create<Production.Projects.IGetProjInfoByCust>(_GetProjInfoByCust);
			
			return iGetProjInfoByCustExt;
		}
	}
}
