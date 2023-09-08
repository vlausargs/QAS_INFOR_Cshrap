//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigInsFactory
	{
		public ISSSFSUnitConfigIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSUnitConfigIns = new Logistics.FieldService.SSSFSUnitConfigIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigInsExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigIns>(_SSSFSUnitConfigIns);
			
			return iSSSFSUnitConfigInsExt;
		}
	}
}
