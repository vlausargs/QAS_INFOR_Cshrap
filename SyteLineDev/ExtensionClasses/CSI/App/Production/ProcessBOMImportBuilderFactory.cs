//PROJECT NAME: Production
//CLASS NAME: ProcessBOMImportBuilderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ProcessBOMImportBuilderFactory
	{
		public IProcessBOMImportBuilder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessBOMImportBuilder = new Production.ProcessBOMImportBuilder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessBOMImportBuilderExt = timerfactory.Create<Production.IProcessBOMImportBuilder>(_ProcessBOMImportBuilder);
			
			return iProcessBOMImportBuilderExt;
		}
	}
}
