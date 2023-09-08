//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncNoteExactRecordDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncNoteExactRecordDateFactory
	{
		public ISSSFSIncNoteExactRecordDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSIncNoteExactRecordDate = new Logistics.FieldService.CallCenter.SSSFSIncNoteExactRecordDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncNoteExactRecordDateExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncNoteExactRecordDate>(_SSSFSIncNoteExactRecordDate);
			
			return iSSSFSIncNoteExactRecordDateExt;
		}
	}
}
