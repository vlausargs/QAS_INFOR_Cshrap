//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigUpdFactory
	{
		public ISSSFSUnitConfigUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSUnitConfigUpd = new Logistics.FieldService.SSSFSUnitConfigUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigUpdExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigUpd>(_SSSFSUnitConfigUpd);
			
			return iSSSFSUnitConfigUpdExt;
		}
	}
}
