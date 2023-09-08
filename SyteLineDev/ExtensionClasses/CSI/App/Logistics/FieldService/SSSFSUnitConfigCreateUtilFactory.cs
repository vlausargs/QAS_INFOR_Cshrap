//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigCreateUtilFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigCreateUtilFactory
	{
		public ISSSFSUnitConfigCreateUtil Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSUnitConfigCreateUtil = new Logistics.FieldService.SSSFSUnitConfigCreateUtil(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitConfigCreateUtilExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitConfigCreateUtil>(_SSSFSUnitConfigCreateUtil);
			
			return iSSSFSUnitConfigCreateUtilExt;
		}
	}
}
