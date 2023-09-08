//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefCreateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefCreateFactory
	{
		public ISSSFSXrefCreate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSXrefCreate = new Logistics.FieldService.SSSFSXrefCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSXrefCreateExt = timerfactory.Create<Logistics.FieldService.ISSSFSXrefCreate>(_SSSFSXrefCreate);
			
			return iSSSFSXrefCreateExt;
		}
	}
}
