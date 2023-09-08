//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmPostSchedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmPostSchedFactory
	{
		public ISSSFSAcmPostSched Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSAcmPostSched = new Logistics.FieldService.SSSFSAcmPostSched(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSAcmPostSchedExt = timerfactory.Create<Logistics.FieldService.ISSSFSAcmPostSched>(_SSSFSAcmPostSched);
			
			return iSSSFSAcmPostSchedExt;
		}
	}
}
