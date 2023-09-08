//PROJECT NAME: Production
//CLASS NAME: ProjcostdetailDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjcostdetailDelFactory
	{
		public IProjcostdetailDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjcostdetailDel = new Production.Projects.ProjcostdetailDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjcostdetailDelExt = timerfactory.Create<Production.Projects.IProjcostdetailDel>(_ProjcostdetailDel);
			
			return iProjcostdetailDelExt;
		}
	}
}
