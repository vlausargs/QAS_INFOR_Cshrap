//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefPromptFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefPromptFactory
	{
		public ISSSFSXrefPrompt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSFSXrefPrompt = new Logistics.FieldService.SSSFSXrefPrompt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSXrefPromptExt = timerfactory.Create<Logistics.FieldService.ISSSFSXrefPrompt>(_SSSFSXrefPrompt);
			
			return iSSSFSXrefPromptExt;
		}
	}
}
