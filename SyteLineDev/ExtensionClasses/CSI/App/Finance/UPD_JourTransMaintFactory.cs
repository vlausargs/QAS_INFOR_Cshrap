//PROJECT NAME: Finance
//CLASS NAME: UPD_JourTransMaintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class UPD_JourTransMaintFactory
	{
		public IUPD_JourTransMaint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UPD_JourTransMaint = new Finance.UPD_JourTransMaint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUPD_JourTransMaintExt = timerfactory.Create<Finance.IUPD_JourTransMaint>(_UPD_JourTransMaint);
			
			return iUPD_JourTransMaintExt;
		}
	}
}
