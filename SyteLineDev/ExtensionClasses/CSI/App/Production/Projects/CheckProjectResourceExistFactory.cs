//PROJECT NAME: Production
//CLASS NAME: CheckProjectResourceExistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class CheckProjectResourceExistFactory
	{
		public ICheckProjectResourceExist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckProjectResourceExist = new Production.Projects.CheckProjectResourceExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckProjectResourceExistExt = timerfactory.Create<Production.Projects.ICheckProjectResourceExist>(_CheckProjectResourceExist);
			
			return iCheckProjectResourceExistExt;
		}
	}
}
