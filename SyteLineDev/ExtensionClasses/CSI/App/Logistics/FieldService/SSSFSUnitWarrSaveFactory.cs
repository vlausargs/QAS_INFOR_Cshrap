//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitWarrSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitWarrSaveFactory
	{
		public ISSSFSUnitWarrSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSUnitWarrSave = new Logistics.FieldService.SSSFSUnitWarrSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSUnitWarrSaveExt = timerfactory.Create<Logistics.FieldService.ISSSFSUnitWarrSave>(_SSSFSUnitWarrSave);
			
			return iSSSFSUnitWarrSaveExt;
		}
	}
}
