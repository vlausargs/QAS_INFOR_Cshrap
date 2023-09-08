//PROJECT NAME: Logistics
//CLASS NAME: ImportVATFilesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ImportVATFilesFactory
	{
		public IImportVATFiles Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ImportVATFiles = new Logistics.Customer.ImportVATFiles(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iImportVATFilesExt = timerfactory.Create<Logistics.Customer.IImportVATFiles>(_ImportVATFiles);
			
			return iImportVATFilesExt;
		}
	}
}
