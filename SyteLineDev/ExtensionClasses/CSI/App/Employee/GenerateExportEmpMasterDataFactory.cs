//PROJECT NAME: Employee
//CLASS NAME: GenerateExportEmpMasterDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class GenerateExportEmpMasterDataFactory
	{
		public IGenerateExportEmpMasterData Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GenerateExportEmpMasterData = new Employee.GenerateExportEmpMasterData(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateExportEmpMasterDataExt = timerfactory.Create<Employee.IGenerateExportEmpMasterData>(_GenerateExportEmpMasterData);
			
			return iGenerateExportEmpMasterDataExt;
		}
	}
}
