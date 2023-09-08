//PROJECT NAME: Production
//CLASS NAME: StartEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class StartEndDateFactory
	{
		public IStartEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _StartEndDate = new Production.Projects.StartEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iStartEndDateExt = timerfactory.Create<Production.Projects.IStartEndDate>(_StartEndDate);
			
			return iStartEndDateExt;
		}
	}
}
