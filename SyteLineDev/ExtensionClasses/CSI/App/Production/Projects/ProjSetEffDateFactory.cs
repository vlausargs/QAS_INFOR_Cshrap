//PROJECT NAME: Production
//CLASS NAME: ProjSetEffDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjSetEffDateFactory
	{
		public IProjSetEffDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjSetEffDate = new Production.Projects.ProjSetEffDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjSetEffDateExt = timerfactory.Create<Production.Projects.IProjSetEffDate>(_ProjSetEffDate);
			
			return iProjSetEffDateExt;
		}
	}
}
