//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcTotalsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcTotalsFactory
	{
		public ISSSFSConInvSubCalcTotals Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSConInvSubCalcTotals = new Logistics.FieldService.SSSFSConInvSubCalcTotals(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConInvSubCalcTotalsExt = timerfactory.Create<Logistics.FieldService.ISSSFSConInvSubCalcTotals>(_SSSFSConInvSubCalcTotals);
			
			return iSSSFSConInvSubCalcTotalsExt;
		}
	}
}
